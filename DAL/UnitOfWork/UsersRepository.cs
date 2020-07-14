using Core.DTO;
using Core.Shared.helpers;
using DAL.Contracts;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    internal class UsersRepository : Repository<Users, UsersDTO>, IUsersRepository
    {
        private readonly LibraryContext _libraryContext;
        public UsersRepository(LibraryContext context) : base(context)
        {
            _libraryContext = context;
        }
        public async Task<Users> GetUserByName(string name)
        {
            return await base._entities.Where(x => x.UserName == name).FirstOrDefaultAsync();
        }

        public int RemoveById(int id)
        {
            var user = new Users { Id = id };
            _entities.Attach(user);
            _entities.Remove(user);
            return id;
        }
    }
}
