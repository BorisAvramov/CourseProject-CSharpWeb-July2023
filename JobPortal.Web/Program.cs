using JobPortal.Data;
using JobPortal.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using JobPortal.Web.Infrastructures.Extensions;

namespace JobPortal.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<JobPortalDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => 
            {

                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireLowercase= false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 4;
                

            })
                //.AddDefaultTokenProviders()
                //.AddRoles<IdentityRole>() 
                .AddEntityFrameworkStores<JobPortalDbContext>();


            builder.Services.AddApplicationServices();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/User/Login";

            });


            builder.Services.AddControllersWithViews();

            var app = builder.Build();



            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();



           await app.RunAsync();
        }
    }
}