using BLL.Contract;
using BLL.Contract.Errors;
using Core.DTO;
using Core.Shared.Consts;
using Core.Shared.ErrorCodes;
using Core.Shared.helpers;
using DAL.Contracts;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Concrete
{
    public class UsersService : AbstractGenericEntityService<Users, UsersDTO>, IUsersService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UsersService(IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IErrorService errorService)
            : base(unitOfWork, errorService, ModulesIndex.USERS_SERVICE)
        {
            _httpContextAccessor = httpContextAccessor;
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
        public async Task<Users> GetUserById(string id)
        {
            try
            {
                return await _unitOfWork.UsersRepo.GetUserById(id);
            }
            catch (Exception ex)
            {
                throw base._errorService.CreateException(ex, this._moduleCode, MethodsIndex.GET_USER_BY_NAME);
            }
        }
        public async Task<Users> GetUserByNameWithRole(string name)
        {
            try
            {
                return await _unitOfWork.UsersRepo.GetUserByNameWithRole(name);
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
                RolesDTO newUserRole = await _unitOfWork.RolesRepo.GetByIdDTO(entity.RolesId);
                CheckForRightToCreateSuperuser(newUserRole);
                var res = await Task.FromResult<Users>(_unitOfWork.UsersRepo.Add(entity));
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
                return res;
            }
            catch (Exception ex)
            {
                throw base._errorService.CreateException(ex, this._moduleCode, MethodsIndex.UPDATE_ENTITY);
            }
        }
        public override async Task Update(UsersDTO user)
        {
            Users res = await _unitOfWork.UsersRepo.GetUserByIdWithRole(user.Id);
            CheckForRight(res);
            res.UserName = user.UserName;
            res.LastName = user.LastName;
            res.FirstName = user.FirstName;
            res.RolesId = user.RolesId;
            res.DOB = user.DOB;
            SaveToDB();
        }
        public async Task RemoveById(int id)
        {
            try
            {
                Users res = await _unitOfWork.UsersRepo.GetUserByIdWithRole(id);
                CheckForRight(res);
                await Task.FromResult<int>(_unitOfWork.UsersRepo.RemoveById(id));
            }
            catch (Exception ex)
            {
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.REMOVE);
            }
        }
        private void CheckForRightToCreateSuperuser(RolesDTO newUserRole)
        {
            string currentUserRole = GetCurrentUserRole();
            if (newUserRole != null &&
                (newUserRole.Name == Role.Superuser) &&
                (currentUserRole != Role.Superuser))
            {
                throw new Exception("Only superuser can create superuser");
            }
        }
        private void CheckForRight(Users user)
        {
            string userRole = GetCurrentUserRole();
            if (userRole != Role.Superuser && user.Roles.Name == Role.Superuser)
            {
                throw new Exception("Cannot update superadmin");
            }
        }
        private string GetCurrentUserRole()
        {
            string res = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            return res;
        }
    }
}
