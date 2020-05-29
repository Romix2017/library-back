using DAL.Contracts;
using DAL.Factories.ContextOptionsBuilderFactory;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;
        // public UnitOfWork(ChurchDBContext context)
        public UnitOfWork(string connectionString)
        {
            _context = new LibraryContext(new ConcreteContextOptionsCreator().Create(connectionString));
            BooksRepo = new BooksRepository(_context);
            BooksHistoryRepo = new BooksHistoryRepository(_context);
            GenresRepo = new GenresRepository(_context);
            RolesRepo = new RolesRepository(_context);
            UsersRepo = new UsersRepository(_context);
        }

        public IBooksRepository BooksRepo { get; }
        public IBooksHistoryRepository BooksHistoryRepo { get; }
        public IGenresRepository GenresRepo { get; }
        public IRolesRepository RolesRepo { get; }
        public IUsersRepository UsersRepo { get; }

        public int Complete()
        {
            using (_context)
            {
                return _context.SaveChanges();
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
