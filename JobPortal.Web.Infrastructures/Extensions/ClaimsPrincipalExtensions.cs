﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.Common.GeneralApplicationConstants;

namespace JobPortal.Web.Infrastructures.Extensions
{
    public static class ClaimsPrincipalExtensions
    {

        public static bool IsAdmin(this ClaimsPrincipal user)
        {

            return user.IsInRole(AdminRoleName);
        }

    }
}
