using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAL.Models
{
    public class DbContextFactory : IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var dbContextBuilder = new DbContextOptionsBuilder<LibraryContext>();
            var connectionString = configuration.GetConnectionString("DatabaseConnection");
            dbContextBuilder.UseSqlServer(connectionString);
            return new LibraryContext(dbContextBuilder.Options);
        }
    }
}
