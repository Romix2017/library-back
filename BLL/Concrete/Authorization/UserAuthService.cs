using BLL.Contract;
using BLL.Contract.Authorization;
using Core.DTO;
using Core.Models.Auth;
using Core.Shared.helpers;
using Core.Shared.Settings;
using DAL.Automapper;
using DAL.Contracts;
using DAL.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CS = Core.Shared.Consts.Consts;
namespace BLL.Concrete.Authorization
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IUsersService _userService;
        private readonly AppSettings _appSettings;
        public UserAuthService(IUsersService userService, AppSettings appSettings,
            ILogger<UserAuthService> log)
        {
            _userService = userService;
            _appSettings = appSettings;
        }
        public async Task<UsersDTO> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            Users user = await this._userService.GetUserByName(username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return Mapping.Mapper.Map<UsersDTO>(user);
        }

        public async Task<RegisterDTO> Create(RegisterDTO user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");
            if (await _userService.GetUserByName(user.Username) != null)
                throw new AppException("Username \"" + user.Username + "\" is already taken");
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            Users newUser = Mapping.Mapper.Map<Users>(user);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;
            newUser.RolesId = CS.DEFAULT_ROLE;
            await this._userService.Add(newUser);
            return user;
        }
        public async Task<UsersDTO> Update(UpdateAuthUserDTO user)
        {
            var userForUpdate = await _userService.GetUserByName(user.Username);
            if (userForUpdate == null)
                throw new AppException("User not found");
            if (!string.IsNullOrWhiteSpace(userForUpdate.Username) && userForUpdate.Username != user.Username)
            {
                if (await _userService.GetUserByName(user.Username) != null)
                    throw new AppException("Username " + user.Username + " is already taken");
                userForUpdate.Username = user.Username;
            }
            if (!string.IsNullOrWhiteSpace(user.FirstName))
                userForUpdate.FirstName = user.FirstName;
            if (!string.IsNullOrWhiteSpace(user.LastName))
                userForUpdate.LastName = user.LastName;
            if (!string.IsNullOrWhiteSpace(user.Password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
                userForUpdate.PasswordHash = passwordHash;
                userForUpdate.PasswordSalt = passwordSalt;
            }

            await _userService.UpdateEntity(userForUpdate);
            return Mapping.Mapper.Map<UsersDTO>(userForUpdate);
        }

        public async Task<LoginModel> IssueToken(LoginDTO loginDTO)
        {
            LoginModel res = null;
            var user = await Authenticate(loginDTO.UserName, loginDTO.Password);
            if (user == null)
                throw new AppException("Username \"" + loginDTO.UserName + "\" is wrong");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            res.tokenString = tokenString;
            res.user = user;
            return res;
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
