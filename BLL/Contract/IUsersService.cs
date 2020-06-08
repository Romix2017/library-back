using Core.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contract
{
    public interface IUsersService : IGenericEntityService<UsersDTO>
    {
        Task<Users> GetUserByName(string name);
        Task<Users> Add(Users entity);
        Task<Users> UpdateEntity(Users entity);
    }
}
