using Core.DTO;
using DAL.Contracts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    internal class BooksRepository : Repository<Books, BooksDTO>, IBooksRepository
    {
        private readonly LibraryContext _libraryContext;
        public BooksRepository(LibraryContext context) : base(context)
        {
            _libraryContext = context;
        }
    }
}
