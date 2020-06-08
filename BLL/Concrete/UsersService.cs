using BLL.Contract;
using Core.DTO;
using DAL.Contracts;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class UsersService : AbstractGenericEntityService<Users, UsersDTO>, IUsersService
    {
        public UsersService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public async Task<Users> GetUserByName(string name)
        {
            try
            {
                return await _unitOfWork.UsersRepo.GetUserByName(name);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Users> Add(Users entity)
        {
            try
            {
                var res = await Task.FromResult<Users>(_unitOfWork.UsersRepo.Add(entity));
                SaveToDB();
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Users> UpdateEntity(Users entity)
        {
            try
            {
                var res = await Task.FromResult<Users>(_unitOfWork.UsersRepo.Update(entity));
                SaveToDB();
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
