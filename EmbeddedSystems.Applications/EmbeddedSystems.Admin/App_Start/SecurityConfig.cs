using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace EmbeddedSystems.Admin
{
    public class SecurityConfig
    {
        public static void Setup()
        {
            WebSecurity.InitializeDatabaseConnection("ESDConnection", "Administrators", "Id", "Email", true);
        }
    }
}