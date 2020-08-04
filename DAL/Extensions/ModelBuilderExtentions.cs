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
            GeneratePasswordHashAndSalt("123456");
            modelBuilder.Entity<Roles>().HasData(
                new Roles
                {
                    Id = 1,
                    Name = "Superuser"
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
