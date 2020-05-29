﻿using Core.DTO;
using DAL.Contracts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    internal class BooksHistoryRepository : Repository<BooksHistory, BooksHistoryDTO>, IBooksHistoryRepository
    {
        private readonly LibraryContext _libraryContext;
        public BooksHistoryRepository(LibraryContext context) : base(context)
        {
            _libraryContext = context;
        }
    }
}
