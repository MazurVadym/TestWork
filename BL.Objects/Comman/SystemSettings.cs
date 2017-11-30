using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Objects.Comman
{
    public static class SystemSettings
    {
        public static string StoreHost => ConfigurationManager.AppSettings["StoreHost"];

        public static string AccessToken => ConfigurationManager.AppSettings["AccessToken"];
    }
}
