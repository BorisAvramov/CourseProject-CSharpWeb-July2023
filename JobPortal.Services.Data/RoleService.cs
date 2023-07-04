using JobPortal.Data;
using JobPortal.Data.Models;
using JobPortal.Services.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Data
{
    public class RoleService : IRoleService
    {
        //private JobPortalDbContext dbContext;

        //private readonly UserManager<ApplicationUser> userManager;
        //private readonly RoleManager<IdentityRole> roleManager;
       

        //public RoleService(JobPortalDbContext _dbContext, UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager)
        //{
        //    this.dbContext = _dbContext;
        //    this.userManager = _userManager;
        //    this.roleManager = _roleManager;
        //}

        //public async Task CreateRole(string roleName)
        //{
        //    if (!await roleManager.RoleExistsAsync(roleName))
        //    {
        //        await roleManager.CreateAsync(new IdentityRole(roleName));
        //    }

        //    await dbContext.SaveChangesAsync();

        //}


        //public async Task AddRoleToApplicationUser(string userId, string roleName)
        //{
        //    ApplicationUser? user = await dbContext
        //        .ApplicationUsers
        //        .FirstOrDefaultAsync(au => au.Id == Guid.Parse(userId));

        //    if (user != null)
        //    {
        //        await userManager.AddToRoleAsync(user, roleName);
        //        await dbContext.SaveChangesAsync();

        //    }

        //}


    }
}
