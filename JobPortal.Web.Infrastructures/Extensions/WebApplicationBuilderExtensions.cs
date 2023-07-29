using JobPortal.Data.Models;
using JobPortal.Services.Data;
using JobPortal.Services.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static JobPortal.Common.GeneralApplicationConstants;

namespace JobPortal.Web.Infrastructures.Extensions
{
    /// <summary>
    /// Add services and interfaces to  application services in IoC container in Program.cs 
    /// </summary>


    public static class WebApplicationBuilderExtensions
    {

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IApplicantService, ApplicantService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ISelectOptionCollectionService, SelectOptionCollectionService>();
            services.AddScoped<IJobOfferService, JobOfferService>();

        }

        public static IApplicationBuilder SeedAdministrator (this IApplicationBuilder app, string email)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> userManager =
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole<Guid>> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    return;
                }

                IdentityRole<Guid> role = new IdentityRole<Guid>(AdminRoleName);

                await roleManager.CreateAsync(role);

                ApplicationUser adminUser =
                  await userManager.FindByEmailAsync(email);

               await  userManager.AddToRoleAsync(adminUser, AdminRoleName );
            })
                .GetAwaiter()
                .GetResult();

            return app; 
        }
    }
}
