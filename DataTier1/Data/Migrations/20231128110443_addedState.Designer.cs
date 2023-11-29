﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20231128110443_addedState")]
    partial class addedState
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Data.Models.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("EventId")
                        .HasColumnType("char(36)");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Data.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AvailablePlaces")
                        .HasColumnType("int");

                    b.Property<Guid>("CafeOwnerId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("EnterteinerId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("state")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CafeOwnerId");

                    b.HasIndex("EnterteinerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("70c38fa9-62ad-438d-a245-3d44bda8675e"),
                            CreationDate = new DateTime(2023, 11, 28, 13, 4, 43, 74, DateTimeKind.Local).AddTicks(6689),
                            Email = "coffeowner@gmail.com",
                            Firstname = "Coffe",
                            Lastname = "Owner",
                            PasswordHash = "616136064",
                            Role = 1,
                            Username = "CoffeOwnerTest"
                        },
                        new
                        {
                            Id = new Guid("ec219f26-9475-4192-922b-484ce92ad381"),
                            CreationDate = new DateTime(2023, 11, 28, 13, 4, 43, 74, DateTimeKind.Local).AddTicks(6771),
                            Email = "normaluser@gmail.com",
                            Firstname = "User",
                            Lastname = "Normal",
                            PasswordHash = "824479591",
                            Role = 0,
                            Username = "normal_user"
                        },
                        new
                        {
                            Id = new Guid("c60f40aa-9028-4036-9c09-192dceb95f73"),
                            CreationDate = new DateTime(2023, 11, 28, 13, 4, 43, 74, DateTimeKind.Local).AddTicks(6790),
                            Email = "enterteiner@gmail.com",
                            Firstname = "Enter",
                            Lastname = "Teiner",
                            PasswordHash = "33361348",
                            Role = 2,
                            Username = "enterteiner"
                        });
                });

            modelBuilder.Entity("Data.Models.Booking", b =>
                {
                    b.HasOne("Data.Models.Event", "Event")
                        .WithMany("Bookings")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Models.Event", b =>
                {
                    b.HasOne("Data.Models.User", "CafeOwner")
                        .WithMany("Events")
                        .HasForeignKey("CafeOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.User", "Enterteiner")
                        .WithMany()
                        .HasForeignKey("EnterteinerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CafeOwner");

                    b.Navigation("Enterteiner");
                });

            modelBuilder.Entity("Data.Models.Event", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}