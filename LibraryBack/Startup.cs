using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Concrete;
using BLL.Concrete.Authorization;
using BLL.Concrete.Errors;
using BLL.Contract;
using BLL.Contract.Authorization;
using BLL.Contract.Errors;
using BLL.Extensions;
using Core.Shared.Consts;
using Core.Shared.Settings;
using DAL.Contracts;
using DAL.UnitOfWork;
using LibraryBack.Extensions;
using LibraryBack.Shared.Consts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using CF = LibraryBack.Shared.Consts.ConfigurationConsts;

namespace LibraryBack
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var settings = _configuration.GetSection("AppSettings").Get<AppSettings>();
            services.AddSingleton(settings);
            services.AddHttpClient();
            services.AddCors(options =>
            {
                options.AddPolicy(name: CF.DEFAULT_CORS_POLICY,
                                  builder =>
                                  {
                                      builder.WithOrigins(settings.CorsPolicy)
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.RegisterBllServices();
            services.AddHttpContextAccessor();
            //Jwt Authentication
            var key = Encoding.UTF8.GetBytes(settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.Events = new JwtBearerEvents
               {
                   OnTokenValidated = context =>
                   {
                       var userService = context.HttpContext.RequestServices.GetRequiredService<IUsersService>();
                       var userId = int.Parse(context.Principal.Identity.Name);
                       var user = userService.GetById(userId);
                       if (user == null)
                       {
                           // return unauthorized if user no longer exists
                           context.Fail("Unauthorized");
                       }
                       return Task.CompletedTask;
                   }
               };
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policy.MainUsersGroup, policy =>
                policy.RequireRole(Role.Admin, Role.Superuser));
                options.AddPolicy(Policy.RegularUsersGroup, policy =>
              policy.RequireRole(Role.User));
                options.AddPolicy(Policy.SupremeUsersGroup, policy =>
            policy.RequireRole(Role.Superuser));
                options.AddPolicy(Policy.AdminUsersGroup, policy =>
          policy.RequireRole(Role.Admin));
                options.AddPolicy(Policy.LimitedUsersGroup, policy =>
          policy.RequireRole(Role.Admin, Role.User));
            });

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
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
            app.UseRouting();
            app.UseCors(CF.DEFAULT_CORS_POLICY);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            loggerFactory.AddFile("Logs/{Date}.txt");
        }
    }
}
