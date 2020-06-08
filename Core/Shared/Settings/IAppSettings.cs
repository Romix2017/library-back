using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Shared.Settings
{
    public interface IAppSettings
    {
        string Secret { get; set; }
        string[] CorsPolicy { get; set; }
    }
}
