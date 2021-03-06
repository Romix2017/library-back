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
    [Migration("20200813123801_AddRequiredDateGiven")]
    partial class AddRequiredDateGiven
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

                    b.Property<bool>("isAvailable")
                        .HasColumnType("bit");

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
                        .IsRequired()
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
                            PasswordHash = new byte[] { 159, 159, 150, 105, 12, 153, 214, 19, 84, 63, 41, 212, 79, 217, 157, 122, 13, 239, 34, 17, 80, 216, 97, 210, 226, 165, 75, 110, 124, 150, 38, 205, 120, 252, 225, 46, 216, 180, 168, 167, 250, 165, 46, 95, 219, 123, 92, 26, 8, 26, 86, 85, 74, 69, 6, 225, 231, 73, 108, 10, 17, 241, 45, 57 },
                            PasswordSalt = new byte[] { 62, 50, 174, 100, 226, 172, 204, 26, 64, 160, 75, 84, 162, 132, 102, 80, 27, 109, 130, 16, 150, 251, 106, 46, 104, 32, 86, 106, 43, 172, 135, 186, 26, 205, 168, 58, 30, 208, 91, 248, 56, 93, 51, 122, 62, 105, 29, 67, 93, 90, 87, 40, 226, 156, 68, 74, 214, 193, 97, 218, 198, 122, 85, 22, 55, 152, 160, 59, 51, 5, 46, 173, 247, 68, 32, 149, 33, 122, 118, 170, 250, 117, 208, 19, 206, 32, 55, 117, 126, 25, 129, 67, 239, 236, 89, 202, 130, 15, 103, 205, 253, 77, 44, 72, 61, 153, 240, 137, 106, 147, 0, 229, 35, 226, 77, 115, 248, 158, 96, 18, 69, 152, 63, 84, 12, 62, 147, 156 },
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RolesId = 1,
                            UserName = "Superuser"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "User",
                            LastName = "User",
                            PasswordHash = new byte[] { 159, 159, 150, 105, 12, 153, 214, 19, 84, 63, 41, 212, 79, 217, 157, 122, 13, 239, 34, 17, 80, 216, 97, 210, 226, 165, 75, 110, 124, 150, 38, 205, 120, 252, 225, 46, 216, 180, 168, 167, 250, 165, 46, 95, 219, 123, 92, 26, 8, 26, 86, 85, 74, 69, 6, 225, 231, 73, 108, 10, 17, 241, 45, 57 },
                            PasswordSalt = new byte[] { 62, 50, 174, 100, 226, 172, 204, 26, 64, 160, 75, 84, 162, 132, 102, 80, 27, 109, 130, 16, 150, 251, 106, 46, 104, 32, 86, 106, 43, 172, 135, 186, 26, 205, 168, 58, 30, 208, 91, 248, 56, 93, 51, 122, 62, 105, 29, 67, 93, 90, 87, 40, 226, 156, 68, 74, 214, 193, 97, 218, 198, 122, 85, 22, 55, 152, 160, 59, 51, 5, 46, 173, 247, 68, 32, 149, 33, 122, 118, 170, 250, 117, 208, 19, 206, 32, 55, 117, 126, 25, 129, 67, 239, 236, 89, 202, 130, 15, 103, 205, 253, 77, 44, 72, 61, 153, 240, 137, 106, 147, 0, 229, 35, 226, 77, 115, 248, 158, 96, 18, 69, 152, 63, 84, 12, 62, 147, 156 },
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RolesId = 2,
                            UserName = "User"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Admin",
                            LastName = "Admin",
                            PasswordHash = new byte[] { 159, 159, 150, 105, 12, 153, 214, 19, 84, 63, 41, 212, 79, 217, 157, 122, 13, 239, 34, 17, 80, 216, 97, 210, 226, 165, 75, 110, 124, 150, 38, 205, 120, 252, 225, 46, 216, 180, 168, 167, 250, 165, 46, 95, 219, 123, 92, 26, 8, 26, 86, 85, 74, 69, 6, 225, 231, 73, 108, 10, 17, 241, 45, 57 },
                            PasswordSalt = new byte[] { 62, 50, 174, 100, 226, 172, 204, 26, 64, 160, 75, 84, 162, 132, 102, 80, 27, 109, 130, 16, 150, 251, 106, 46, 104, 32, 86, 106, 43, 172, 135, 186, 26, 205, 168, 58, 30, 208, 91, 248, 56, 93, 51, 122, 62, 105, 29, 67, 93, 90, 87, 40, 226, 156, 68, 74, 214, 193, 97, 218, 198, 122, 85, 22, 55, 152, 160, 59, 51, 5, 46, 173, 247, 68, 32, 149, 33, 122, 118, 170, 250, 117, 208, 19, 206, 32, 55, 117, 126, 25, 129, 67, 239, 236, 89, 202, 130, 15, 103, 205, 253, 77, 44, 72, 61, 153, 240, 137, 106, 147, 0, 229, 35, 226, 77, 115, 248, 158, 96, 18, 69, 152, 63, 84, 12, 62, 147, 156 },
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
