using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Contract;
using BLL.Contract.Authorization;
using Core.DTO;
using Core.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBack.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserAuthService _userAuthService;
        private readonly IUsersService _usersService;
        public LoginController(IUserAuthService userAuthService, IUsersService userService)
        {
            _userAuthService = userAuthService;
            _usersService = userService;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginDTO loginDTO)
        {
            try
            {
                LoginModel loginModel = await _userAuthService.IssueToken(loginDTO);
                return Ok(new
                {
                    loginModel.user.Id,
                    loginModel.user.Username,
                    loginModel.user.FirstName,
                    loginModel.user.LastName,
                    Token = loginModel.tokenString
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerModel)
        {
            try
            {
                await _userAuthService.Create(registerModel, registerModel.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _usersService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _usersService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateAuthUserDTO user)
        {
            try
            {

                return Ok(await _userAuthService.Update(user));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(UsersDTO user)
        {
            try
            {
                return Ok(await _usersService.Remove(user));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}