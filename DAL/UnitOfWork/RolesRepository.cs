using Core.DTO;
using DAL.Contracts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    internal class RolesRepository : Repository<Roles, RolesDTO>, IRolesRepository
    {
        private readonly LibraryContext _libraryContext;
        public RolesRepository(LibraryContext context) : base(context)
        {
            _libraryContext = context;
        }
    }
}
