using JobPortal.Services.Data.Interfaces;
using JobPortal.Web.ViewModels.Applicant;
using JobPortal.Web.ViewModels.Company;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using static JobPortal.Common.NotificationMessageConstants;

namespace JobPortal.Web.Controllers
{
    public class ApplicantController : BaseController
    {
        private readonly IApplicantService applicantService;
        private readonly IRoleService roleService;

        public ApplicantController(IApplicantService _applicantService, IRoleService _roleService)
        {
            this.applicantService = _applicantService;
            this.roleService = _roleService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool IsApplicant = await this.applicantService.ApplicantExistsByUserId(userId);

            if (IsApplicant)
            {
                this.TempData[ErrorMessage] = "You are already an applicant!";

                return RedirectToAction("Index", "Home");
            }

            BecomeApplicantFormModel model = new BecomeApplicantFormModel()
            {
                Towns = await applicantService.GetTowns(),
                ProgrammingLanguages = await applicantService.GetProgrammingLanguages(),
                Levels = await applicantService.GetLevels()
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeApplicantFormModel model)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool IsApplicant = await this.applicantService.ApplicantExistsByUserId(userId);

            if (IsApplicant)
            {
                this.TempData[ErrorMessage] = "You are already a recruiter!";

                return RedirectToAction("Index", "Home");
            }


            bool isPhoneNumberTaken = await this.applicantService.ApplicantExistsByPhoneNumber(model.Phone);

            if (isPhoneNumberTaken)
            {
                this.TempData[ErrorMessage] = "Applicant with the provided phone number already exists!";
                this.ModelState.AddModelError(nameof(model.Phone), "Applicant with the provided phone number already exists!");
                return View(model);

            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {


                await applicantService.Create(model, userId);
                this.TempData[SuccessMessage] = "Successfull registration as an applicant!";

                //await roleService.CreateRole("applicant");
                //await roleService.AddRoleToApplicationUser(userId, "applicant");

            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred while registering you as an applicant! Please try again later or contact administrator!";
                return RedirectToAction("Index", "Home");


            }



            return RedirectToAction("Index", "Home");
        }
    }
}
