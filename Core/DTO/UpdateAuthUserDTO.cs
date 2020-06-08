using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class UpdateAuthUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }
        public int RolesId { get; set; }
    }
}
