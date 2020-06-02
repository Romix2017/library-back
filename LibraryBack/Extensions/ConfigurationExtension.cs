using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBack.Extensions
{
    public static class ConfigurationExtension
    {
        public static string[] GetAllowedCorsOrigins(this IConfiguration configuration, string name)
        {
            var res = configuration
                            .GetSection(name)
                            .GetChildren()
                            .Select(x => x.Value)
                            .ToArray();
            return res;
        }
    }
}
