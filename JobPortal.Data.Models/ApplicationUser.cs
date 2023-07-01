﻿using Microsoft.AspNetCore.Identity;

namespace JobPortal.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }

    }
}