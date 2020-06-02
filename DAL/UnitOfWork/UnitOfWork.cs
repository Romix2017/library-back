using Core.DTO;
using DAL.Contracts;
using DAL.Factories.ContextOptionsBuilderFactory;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public IRepository<T, TDto> GetRepo<T, TDto>(Type entity) where T : class where TDto : class
        {
            switch (entity.Name)
            {
                case nameof(BooksHistoryDTO):
                    return (IRepository<T, TDto>)BooksHistoryRepo;
                case nameof(BooksDTO):
                    return (IRepository<T, TDto>)BooksRepo;
                case nameof(GenresDTO):
                    return (IRepository<T, TDto>)GenresRepo;
                case nameof(RolesDTO):
                    return (IRepository<T, TDto>)RolesRepo;
                case nameof(UsersDTO):
                    return (IRepository<T, TDto>)UsersRepo;
                default:
                    return null;
            }
        }

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
