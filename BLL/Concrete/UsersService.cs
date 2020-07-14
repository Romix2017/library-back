using BLL.Contract;
using BLL.Contract.Errors;
using Core.DTO;
using Core.Shared.ErrorCodes;
using Core.Shared.helpers;
using DAL.Contracts;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Concrete
{
    public class UsersService : AbstractGenericEntityService<Users, UsersDTO>, IUsersService
    {
        public UsersService(IUnitOfWork unitOfWork, IErrorService errorService)
            : base(unitOfWork, errorService, ModulesIndex.USERS_SERVICE)
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
                throw base._errorService.CreateException(ex, this._moduleCode, MethodsIndex.GET_USER_BY_NAME);
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
                throw base._errorService.CreateException(ex, this._moduleCode, MethodsIndex.ADD_ENTITY);
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
                throw base._errorService.CreateException(ex, this._moduleCode, MethodsIndex.UPDATE_ENTITY);
            }
        }
        public async Task RemoveById(int id)
        {
            try
            {
                await Task.FromResult<int>(_unitOfWork.UsersRepo.RemoveById(id));
                SaveToDB();
            }
            catch (Exception ex)
            {
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.REMOVE);
            }
        }
    }
}
