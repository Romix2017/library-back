﻿// <auto-generated />
using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20200813070140_AddSeedInfo")]
    partial class AddSeedInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.Books", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Notation")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("PublishingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GenresId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("DAL.Models.BooksHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateGiven")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateReturned")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BooksId");

                    b.HasIndex("UsersId");

                    b.ToTable("BooksHistory");
                });

            modelBuilder.Entity("DAL.Models.Genres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("DAL.Models.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Superuser"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("DAL.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("RolesId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Superuser",
                            LastName = "Superuser",
                            PasswordHash = new byte[] { 82, 136, 187, 253, 57, 52, 2, 33, 39, 169, 234, 6, 55, 8, 14, 188, 190, 111, 182, 165, 244, 216, 184, 134, 182, 174, 162, 113, 23, 202, 71, 98, 243, 100, 6, 70, 3, 39, 239, 223, 68, 43, 117, 160, 0, 122, 39, 254, 180, 215, 21, 232, 16, 34, 9, 208, 225, 211, 63, 61, 133, 34, 105, 14 },
                            PasswordSalt = new byte[] { 13, 13, 48, 207, 119, 24, 57, 33, 105, 246, 190, 123, 125, 254, 135, 142, 60, 122, 234, 130, 214, 28, 87, 234, 121, 120, 65, 224, 202, 214, 191, 178, 218, 6, 214, 180, 238, 111, 215, 192, 99, 12, 41, 14, 136, 61, 147, 188, 200, 105, 90, 251, 139, 103, 196, 116, 110, 132, 122, 252, 236, 101, 76, 56, 16, 12, 20, 83, 85, 102, 91, 145, 86, 125, 89, 134, 43, 93, 254, 10, 13, 13, 74, 5, 84, 168, 245, 6, 159, 87, 126, 227, 87, 21, 181, 21, 15, 250, 7, 107, 48, 137, 92, 7, 38, 222, 86, 96, 49, 89, 189, 2, 98, 210, 22, 40, 1, 171, 238, 120, 153, 24, 232, 212, 189, 151, 160, 113 },
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RolesId = 1,
                            UserName = "Superuser"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "User",
                            LastName = "User",
                            PasswordHash = new byte[] { 82, 136, 187, 253, 57, 52, 2, 33, 39, 169, 234, 6, 55, 8, 14, 188, 190, 111, 182, 165, 244, 216, 184, 134, 182, 174, 162, 113, 23, 202, 71, 98, 243, 100, 6, 70, 3, 39, 239, 223, 68, 43, 117, 160, 0, 122, 39, 254, 180, 215, 21, 232, 16, 34, 9, 208, 225, 211, 63, 61, 133, 34, 105, 14 },
                            PasswordSalt = new byte[] { 13, 13, 48, 207, 119, 24, 57, 33, 105, 246, 190, 123, 125, 254, 135, 142, 60, 122, 234, 130, 214, 28, 87, 234, 121, 120, 65, 224, 202, 214, 191, 178, 218, 6, 214, 180, 238, 111, 215, 192, 99, 12, 41, 14, 136, 61, 147, 188, 200, 105, 90, 251, 139, 103, 196, 116, 110, 132, 122, 252, 236, 101, 76, 56, 16, 12, 20, 83, 85, 102, 91, 145, 86, 125, 89, 134, 43, 93, 254, 10, 13, 13, 74, 5, 84, 168, 245, 6, 159, 87, 126, 227, 87, 21, 181, 21, 15, 250, 7, 107, 48, 137, 92, 7, 38, 222, 86, 96, 49, 89, 189, 2, 98, 210, 22, 40, 1, 171, 238, 120, 153, 24, 232, 212, 189, 151, 160, 113 },
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RolesId = 2,
                            UserName = "User"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Admin",
                            LastName = "Admin",
                            PasswordHash = new byte[] { 82, 136, 187, 253, 57, 52, 2, 33, 39, 169, 234, 6, 55, 8, 14, 188, 190, 111, 182, 165, 244, 216, 184, 134, 182, 174, 162, 113, 23, 202, 71, 98, 243, 100, 6, 70, 3, 39, 239, 223, 68, 43, 117, 160, 0, 122, 39, 254, 180, 215, 21, 232, 16, 34, 9, 208, 225, 211, 63, 61, 133, 34, 105, 14 },
                            PasswordSalt = new byte[] { 13, 13, 48, 207, 119, 24, 57, 33, 105, 246, 190, 123, 125, 254, 135, 142, 60, 122, 234, 130, 214, 28, 87, 234, 121, 120, 65, 224, 202, 214, 191, 178, 218, 6, 214, 180, 238, 111, 215, 192, 99, 12, 41, 14, 136, 61, 147, 188, 200, 105, 90, 251, 139, 103, 196, 116, 110, 132, 122, 252, 236, 101, 76, 56, 16, 12, 20, 83, 85, 102, 91, 145, 86, 125, 89, 134, 43, 93, 254, 10, 13, 13, 74, 5, 84, 168, 245, 6, 159, 87, 126, 227, 87, 21, 181, 21, 15, 250, 7, 107, 48, 137, 92, 7, 38, 222, 86, 96, 49, 89, 189, 2, 98, 210, 22, 40, 1, 171, 238, 120, 153, 24, 232, 212, 189, 151, 160, 113 },
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RolesId = 3,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("DAL.Models.Books", b =>
                {
                    b.HasOne("DAL.Models.Genres", "Genres")
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.BooksHistory", b =>
                {
                    b.HasOne("DAL.Models.Books", "Books")
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DAL.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.Users", b =>
                {
                    b.HasOne("DAL.Models.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}