
using JobPortal.Services.Data.Interfaces;
using JobPortal.Web.ViewModels.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace JobPortal.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICompanyService companyService;

        public HomeController(ICompanyService _companyService)
        {
            this.companyService = _companyService;
        }

        

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                string? userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                bool IsCompany = await companyService.CompanyExistsByUserId(userId);

                if (IsCompany)
                {
                    return View("CompanyIndex");
                }

                //return RedirectToAction("All", "Movies");

            }


            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}