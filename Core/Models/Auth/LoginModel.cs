using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Auth
{
    public class LoginModel
    {
        public string tokenString { get; set; }
        public UsersDTO user { get; set; }
    }
}
