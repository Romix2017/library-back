using Core.DTO;
using Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contract.Authorization
{
    public interface IUserAuthService
    {
        Task<UsersDTO> Authenticate(string username, string password);
        Task<RegisterDTO> Create(RegisterDTO user, string password);
        Task<UsersDTO> Update(UpdateAuthUserDTO user);
        Task<LoginModel> IssueToken(LoginDTO loginDTO);
        Task<LoginModel> Refresh(LoginModel loginModel);
        Task Revoke(LoginModel loginModel);
    }
}
