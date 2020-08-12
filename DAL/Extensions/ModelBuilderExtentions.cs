using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DAL.Extensions
{
    public static class ModelBuilderExtentions
    {
        private static byte[] passwordHash;
        private static byte[] passwordSalt;
        public static void Seed(this ModelBuilder modelBuilder)
        {
            GeneratePasswordHashAndSalt("123");
            modelBuilder.Entity<Roles>().HasData(
                new Roles
                {
                    Id = 1,
                    Name = "Superuser"
                },
                new Roles
                {
                    Id = 2,
                    Name = "User"
                },
                new Roles
                {
                    Id = 3,
                    Name = "Admin"
                });
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = 1,
                    FirstName = "Superuser",
                    LastName = "Superuser",
                    UserName = "Superuser",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    RolesId = 1
                },
                new Users
                {
                    Id = 2,
                    FirstName = "User",
                    LastName = "User",
                    UserName = "User",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    RolesId = 2
                },
                new Users
                {
                    Id = 3,
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "Admin",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    RolesId = 3
                });
        }
        private static void GeneratePasswordHashAndSalt(string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                passwordSalt = hmac.Key;
            }
        }
    }
}
