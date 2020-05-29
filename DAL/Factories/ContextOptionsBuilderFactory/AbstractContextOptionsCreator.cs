using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Factories.ContextOptionsBuilderFactory
{
    abstract class AbstractContextOptionsCreator<TContext> where TContext : DbContext
    {
        public abstract DbContextOptions<TContext> Create(string connectionString);
    }
}
