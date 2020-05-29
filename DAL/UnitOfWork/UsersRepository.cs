using Core.DTO;
using DAL.Contracts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    internal class UsersRepository : Repository<Users, UsersDTO>, IUsersRepository
    {
        private readonly LibraryContext _libraryContext;
        public UsersRepository(LibraryContext context) : base(context)
        {
            _libraryContext = context;
        }
    }
}
