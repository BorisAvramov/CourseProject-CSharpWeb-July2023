﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Web.ViewModels.User
{
    /// <summary>
    /// User View Model with properties to show in Admin Area
    /// </summary>

    public class UserViewModel
    {
        public string Id { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
