using Core.DTO;
using DAL.Contracts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.UnitOfWork
{
    internal class BooksRepository : Repository<Books, BooksDTO>, IBooksRepository
    {
        //private readonly LibraryContext _libraryContext;
        public BooksRepository(LibraryContext context) : base(context)
        {
            //_libraryContext = context;
        }
        public int RemoveById(int id)
        {
            var book = new Books { Id = id };
            _entities.Attach(book);
            _entities.Remove(book);
            this.Complete();
            return id;
        }
    }
}
