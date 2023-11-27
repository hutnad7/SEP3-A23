using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();
             modelBuilder.Entity<Event>()
    .HasOne(e => e.CafeOwner)
    .WithMany(e => e.Events)
    .HasForeignKey(e => e.CafeOwnerId)
    .IsRequired();
             
            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    Id = Guid.NewGuid(),
                    Firstname = "Coffe",
                    Lastname = "Owner",
                    Username = "CoffeOwnerTest",
                    Email = "coffeowner@gmail.com",
                    CreationDate = DateTime.Now,
                    Role = Role.CafeOwner,
                    PasswordHash = "CafePa33word".GetHashCode().ToString(),
                });
            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    Id = Guid.NewGuid(),
                    Firstname = "User",
                    Lastname = "Normal",
                    Username = "normal_user",
                    Email = "normaluser@gmail.com",
                    CreationDate = DateTime.Now,
                    Role = Role.User,
                    PasswordHash = "UserPa33word".GetHashCode().ToString(),
                });
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Firstname = "Enter",
                    Lastname = "Teiner",
                    Username = "enterteiner",
                    Email = "enterteiner@gmail.com",
                    CreationDate = DateTime.Now,
                    Role = Role.Enterteiner,
                    PasswordHash = "EntrPa33word".GetHashCode().ToString(),
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}