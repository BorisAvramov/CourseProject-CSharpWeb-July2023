using JobPortal.Services.Data;
using JobPortal.Services.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Web.Infrastructures.Extensions
{
    public static class WebApplicationBuilderExtensions
    {

        public static void AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IApplicantService, ApplicantService>();
            services.AddScoped<IRoleService, RoleService>();

        }
    }
}
