using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RVAS_Kosarka.Models
{
    public static class RoleName
    {
        public const string RegularUser = "RegularUser";
        public const string AdminUser = "Admin";

        public const string AdminOrRegularUser = AdminUser + "," + RegularUser;
    }
}