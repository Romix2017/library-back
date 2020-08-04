using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete.Models
{
    public class PasswordModel
    {
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
    }
}
