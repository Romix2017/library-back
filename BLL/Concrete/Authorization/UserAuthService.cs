using BLL.Concrete.Models;
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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CS = Core.Shared.Consts.Consts;
namespace BLL.Concrete.Authorization
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IUsersService _userService;
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitOfWork;
        public UserAuthService(IUsersService userService,
            IUnitOfWork unitOfWork, AppSettings appSettings,
            ILogger<UserAuthService> log)
        {
            _userService = userService;
            _appSettings = appSettings;
            _unitOfWork = unitOfWork;
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
        public async Task<Users> AuthenticateNoMap(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            Users user = await this._userService.GetUserByName(username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<RegisterDTO> Create(RegisterDTO user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");
            if (await _userService.GetUserByName(user.Username) != null)
                throw new AppException("Username \"" + user.Username + "\" is already taken");
            PasswordModel model = CreatePasswordHashModel(password);
            Users newUser = Mapping.Mapper.Map<Users>(user);
            newUser.PasswordHash = model.passwordHash;
            newUser.PasswordSalt = model.passwordSalt;
            newUser.RolesId = CS.DEFAULT_ROLE;
            await this._userService.Add(newUser);
            return user;
        }
        public async Task<UsersDTO> Update(UpdateAuthUserDTO user)
        {
            var userForUpdate = await _userService.GetUserByName(user.UserName);
            if (userForUpdate == null)
                throw new AppException("User not found");
            if (!string.IsNullOrWhiteSpace(userForUpdate.UserName) && userForUpdate.UserName != user.UserName)
            {
                if (await _userService.GetUserByName(user.UserName) != null)
                    throw new AppException("Username " + user.UserName + " is already taken");
                userForUpdate.UserName = user.UserName;
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
            LoginModel res = new LoginModel();
            Users user = await AuthenticateNoMap(loginDTO.UserName, loginDTO.Password);
            if (user == null)
                throw new AppException("Username \"" + loginDTO.UserName + "\" is wrong");
            IEnumerable<Claim> claimsList = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            };
            var accessToken = GenerateAccessToken(claimsList);
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            res.tokenString = accessToken;
            res.user = Mapping.Mapper.Map<UsersDTO>(user);
            res.refreshToken = refreshToken;
            _unitOfWork.UsersRepo.Complete();
            return res;
        }
        public async Task<LoginModel> Refresh(LoginModel loginModel)
        {
            LoginModel res = new LoginModel();
            if (loginModel is null)
            {
                throw new AppException("Invalid client request");
            }
            string accessToken = loginModel.tokenString;
            string refreshToken = loginModel.refreshToken;
            var principal = GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name;
            var user = await _userService.GetUserByName(username);
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new AppException("Invalid client request");
            }
            var newAccessToken = GenerateAccessToken(principal.Claims);
            var newRefreshToken = GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            res.tokenString = newAccessToken;
            res.refreshToken = newRefreshToken;
            return res;
        }
        public async Task Revoke(LoginModel loginModel)
        {
            string accessToken = loginModel.tokenString;
            var principal = GetPrincipalFromExpiredToken(accessToken);
            var user = await _userService.GetUserByName(principal.Identity.Name);
            user.RefreshToken = null;
            _unitOfWork.UsersRepo.Complete();
        }
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret)),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }
        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            string res = "";
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            res = tokenHandler.WriteToken(token);
            return res;
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
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
        private PasswordModel CreatePasswordHashModel(string password)
        {
            PasswordModel model = new PasswordModel();
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                model.passwordSalt = hmac.Key;
                model.passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            return model;
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
