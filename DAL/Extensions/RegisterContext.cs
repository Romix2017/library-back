using AutoMapper.Configuration;
using DAL.Contracts;
using DAL.Models;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace DAL.Extensions
{
    public static class RegisterContextExtension
    {
        public static IServiceCollection RegisterContext(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json")
                     .Build();
            services.AddDbContext<LibraryContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection"));
                }, ServiceLifetime.Transient);
            services.AddTransient<IBooksHistoryRepository, BooksHistoryRepository>();
            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<IGenresRepository, GenresRepository>();
            services.AddTransient<IRolesRepository, RolesRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            return services;
        }
    }
}
