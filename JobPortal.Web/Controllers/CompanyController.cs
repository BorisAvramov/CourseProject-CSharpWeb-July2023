using JobPortal.Data;
using JobPortal.Data.Models;
using JobPortal.Services.Data.Interfaces;
using JobPortal.Web.Infrastructures.Extensions;
using JobPortal.Web.ViewModels.Company;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

using static JobPortal.Common.NotificationMessageConstants;

namespace JobPortal.Web.Controllers
{
    public class CompanyController : BaseController
    {

        private readonly ICompanyService companyService;
        private readonly IApplicantService applicantService;


        public CompanyController(ICompanyService _companyService, IApplicantService _applicantService)
        {
            this.companyService = _companyService;
          
            this.applicantService = _applicantService;
        }

        /// <summary>
        /// Add Company entity. User becomes Company
        /// </summary>
        /// <returns></returns>


        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            

            bool IsCompany = await this.companyService.CompanyExistsByUserId(userId);
            bool IsApplicant = await this.applicantService.ApplicantExistsByUserId(userId);

            if (IsCompany)
            {
                this.TempData[ErrorMessage] = "You are already a recruiter!";

                return RedirectToAction("Index", "Home");
            }
            if (IsApplicant)
            {
                this.TempData[ErrorMessage] = "Applicant cannot become a recruiter!";

                return RedirectToAction("Index", "Home");
            }



            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Become(BecomeRecruiterFormModel model)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            bool IsCompany = await this.companyService.CompanyExistsByUserId(userId);
            bool IsApplicant = await this.applicantService.ApplicantExistsByUserId(userId);

            if (IsCompany && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You are already a recruiter!";

                return RedirectToAction("Index", "Home");
            }
            if (IsApplicant && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "Applicant cannot become a recruiter!";

                return RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken = await this.companyService.CompanyExistsByPhoneNumber(model.Phone);

            if (isPhoneNumberTaken)
            {
                this.TempData[ErrorMessage] = "Company with the provided phone number already exists!";
                this.ModelState.AddModelError(nameof(model.Phone), "Company with the provided phone number already exists!");
                return View(model);

            }

            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

            try
            {


                await companyService.Create(model, userId);
                this.TempData[SuccessMessage] = "Successfull registration as a recruiter!";

               

            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred while registering you as an recruiter! Please try again later or contact administrator!";
                return RedirectToAction("Index", "Home");


            }



            return RedirectToAction("Index", "Home");
        }



    }
}
