using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class UsersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public int RolesId { get; set; }
    }
}
