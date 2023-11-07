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
    [Migration("20231107140620_h1")]
    partial class h1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Data.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

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
                            Id = new Guid("e8f48659-94a3-4bb6-90e3-a086bfbce13a"),
                            CreationDate = new DateTime(2023, 11, 7, 16, 6, 20, 346, DateTimeKind.Local).AddTicks(8902),
                            Email = "coffeowner@gmail.com",
                            Firstname = "Coffe",
                            Lastname = "Owner",
                            PasswordHash = "2046887701",
                            Role = 1,
                            Username = "CoffeOwnerTest"
                        },
                        new
                        {
                            Id = new Guid("1270a734-8eb9-437c-92a6-bfa1a78151d9"),
                            CreationDate = new DateTime(2023, 11, 7, 16, 6, 20, 346, DateTimeKind.Local).AddTicks(9000),
                            Email = "enterteiner@gmail.com",
                            Firstname = "Enter",
                            Lastname = "Teiner",
                            PasswordHash = "1920443052",
                            Role = 2,
                            Username = "enterteiner"
                        });
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

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
