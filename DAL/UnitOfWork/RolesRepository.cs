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
        //private readonly LibraryContext _libraryContext;
        public RolesRepository(LibraryContext context) : base(context)
        {
            //_libraryContext = context;
        }

        public int RemoveById(int id)
        {
            var role = new Roles { Id = id };
            _entities.Attach(role);
            _entities.Remove(role);
            this.Complete();
            return id;
        }
    }
}
