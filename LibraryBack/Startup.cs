using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Concrete;
using BLL.Contract;
using DAL.Contracts;
using DAL.UnitOfWork;
using LibraryBack.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using CF = LibraryBack.Shared.Consts.ConfigurationConsts;

namespace LibraryBack
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddCors(options =>
            {
                options.AddPolicy(name: CF.DEFAULT_CORS_POLICY,
                                  builder =>
                                  {
                                      builder.WithOrigins(Configuration.GetAllowedCorsOrigins(CF.CORS_POLICY));
                                  });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddScoped<IUnitOfWork>(s => new UnitOfWork(Configuration.GetConnectionString(CF.DATABASE_CONNECTION)));
            services.AddScoped<IBooksHistoryService, BooksHistoryService>();
            services.AddScoped<IBooksService, BooksService>();
            services.AddScoped<IGenresService, GenresService>();
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<IUsersService, UsersService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });
            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(CF.DEFAULT_CORS_POLICY);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
