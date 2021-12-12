using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace JobsAPI.Helpers
{
    public class AccountHelper
    {
        
        public static string GetAccountName(HttpContext context)
        {
            IPrincipal p = context.User;
            string user = Regex.Match(p.Identity.Name, @"\d+").Value;
            user = "057724817"; // test user
            return user;
        }
    }
}
