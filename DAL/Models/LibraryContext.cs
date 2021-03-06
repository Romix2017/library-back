﻿using DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() { }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<BooksHistory> BooksHistory { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=MyLibrary;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>()
                .HasOne(p => p.Genres)
                .WithMany()
                .HasForeignKey(k => k.GenresId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Books>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
                entity.Property(e => e.Author)
                .IsRequired()
                .HasMaxLength(200);
                entity.Property(e => e.PublishingDate)
                .HasColumnType("datetime2");
                entity.Property(e => e.Notation)
                .HasMaxLength(500);
                entity.Property(e => e.isAvailable)
                .HasDefaultValue(true);
            });
            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired();
            });
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsRequired();
                entity.Property(e => e.DOB)
                .HasColumnType("datetime2");
            });
            modelBuilder.Entity<Users>()
                .HasOne(x => x.Roles)
                .WithMany()
                .HasForeignKey(x => x.RolesId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Genres>(entity =>
            {
                entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();
            });
            modelBuilder.Entity<BooksHistory>(entity =>
            {
                entity.Property(e => e.DateGiven)
                .IsRequired()
                .HasColumnType("datetime2");
                entity.Property(e => e.DateReturned)
                .HasColumnType("datetime2");
            });
            modelBuilder.Entity<BooksHistory>()
               .HasOne(x => x.Books)
               .WithMany()
               .HasForeignKey(x => x.BooksId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<BooksHistory>()
                .HasOne(x => x.Users)
                .WithMany()
                .HasForeignKey(x => x.UsersId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Seed();
        }
    }
}
