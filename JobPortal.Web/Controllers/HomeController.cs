
using JobPortal.Services.Data.Interfaces;
using JobPortal.Web;
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
        private readonly IApplicantService applicantService;

        public HomeController(ICompanyService _companyService, IApplicantService _applicantService)
        {
            this.companyService = _companyService;
            this.applicantService = _applicantService;
        }

        

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                string? userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                bool IsCompany = await companyService.CompanyExistsByUserId(userId);
                bool isApplicant = await applicantService.ApplicantExistsByUserId(userId);

                if (IsCompany)
                {
                    return View("CompanyIndex");
                }
                if (isApplicant)
                {
                    return View("ApplicantIndex");

                }

                //return RedirectToAction("All", "Movies");

            }


            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if(statusCode == 400 || statusCode == 404)
            {
                return this.View("Error404");
            }
            return this.View();
        }
    }
}