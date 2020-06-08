using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Shared.Settings
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string[] CorsPolicy { get; set; }
    }
}
