using BLL.Concrete;
using BLL.Concrete.Authorization;
using BLL.Concrete.Errors;
using BLL.Contract;
using BLL.Contract.Authorization;
using BLL.Contract.Errors;
using DAL.Contracts;
using DAL.Extensions;
using DAL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterBllServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBooksHistoryService, BooksHistoryService>();
            services.AddTransient<IBooksService, BooksService>();
            services.AddTransient<IGenresService, GenresService>();
            services.AddTransient<IRolesService, RolesService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IUserAuthService, UserAuthService>();
            services.AddTransient<IUserAuthService, UserAuthService>();
            services.AddSingleton<IErrorService, ErrorService>();
            services.RegisterContext();
            return services;
        }
    }
}
