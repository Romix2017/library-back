using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Factories.ContextOptionsBuilderFactory
{
    class ConcreteContextOptionsCreator : AbstractContextOptionsCreator<LibraryContext>
    {
        public override DbContextOptions<LibraryContext> Create(string connectionString)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().Build();
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            return builder.UseSqlServer(connectionString).Options;
        }
    }
}
