using Core.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IUsersRepository : IRepository<Users, UsersDTO>
    {
        Task<Users> GetUserByName(string name);
        int RemoveById(int id);
        Task<Users> GetUserByNameWithRole(string name);
        Task<Users> GetUserById(string id);
    }
}
