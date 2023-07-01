﻿using JobPortal.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Data
{
    public class JobPortalDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public JobPortalDbContext(DbContextOptions<JobPortalDbContext> options)
            : base(options)
        {


        }
    }
}