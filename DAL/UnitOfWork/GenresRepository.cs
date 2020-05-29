﻿using Core.DTO;
using DAL.Contracts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    internal class GenresRepository : Repository<Genres, GenresDTO>, IGenresRepository
    {
        private readonly LibraryContext _libraryContext;
        public GenresRepository(LibraryContext context) : base(context)
        {
            _libraryContext = context;
        }
    }
}
