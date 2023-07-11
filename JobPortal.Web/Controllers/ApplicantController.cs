using JobPortal.Data.Models;
using JobPortal.Services.Data;
using JobPortal.Services.Data.Interfaces;
using JobPortal.Web.ViewModels.Applicant;
using JobPortal.Web.ViewModels.Company;
using JobPortal.Web.ViewModels.JobOffer;
using JopPortal.Services.Data.Models.Applicant;
using JopPortal.Services.Data.Models.JobOffer;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using static JobPortal.Common.NotificationMessageConstants;

namespace JobPortal.Web.Controllers
{
    public class ApplicantController : BaseController
    {
        private readonly IApplicantService applicantService;
        private readonly ICompanyService companyService;
        private readonly ISelectOptionCollectionService selectOptionCollectionService;
        private readonly IRoleService roleService;
        private readonly IJobOfferService jobOfferService;

        public ApplicantController(IApplicantService _applicantService, ICompanyService _companyService, IRoleService _roleService, ISelectOptionCollectionService _selectOptionCollectionService, IJobOfferService _jobOfferService)
        {
            this.applicantService = _applicantService;
            this.companyService= _companyService;
            this.roleService = _roleService;
            this.selectOptionCollectionService = _selectOptionCollectionService;
            this.jobOfferService = _jobOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool IsApplicant = await this.applicantService.ApplicantExistsByUserId(userId);
            bool IsCompany = await this.companyService.CompanyExistsByUserId(userId);


            if (IsApplicant)
            {
                this.TempData[ErrorMessage] = "You are already an applicant!";

                return RedirectToAction("Index", "Home");
            }
            if (IsCompany)
            {
                this.TempData[ErrorMessage] = "Recruiter cannot become an applicant!";

                return RedirectToAction("Index", "Home");
            }

            BecomeApplicantFormModel model = new BecomeApplicantFormModel()
            {
                Towns = await selectOptionCollectionService.GetTowns(),
                ProgrammingLanguages = await selectOptionCollectionService.GetProgrammingLanguages(),
                Levels = await selectOptionCollectionService.GetLevels()
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeApplicantFormModel model)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool IsApplicant = await this.applicantService.ApplicantExistsByUserId(userId);
            bool IsCompany = await this.companyService.CompanyExistsByUserId(userId);


            if (IsApplicant)
            {
                this.TempData[ErrorMessage] = "You are already an applicant!";

                return RedirectToAction("Index", "Home");
            }
            if (IsCompany)
            {
                this.TempData[ErrorMessage] = "Recruiter cannot become an applicant!";

                return RedirectToAction("Index", "Home");
            }


            bool isPhoneNumberTaken = await this.applicantService.ApplicantExistsByPhoneNumber(model.Phone);

            if (isPhoneNumberTaken)
            {
                this.TempData[ErrorMessage] = "Applicant with the provided phone number already exists!";
                this.ModelState.AddModelError(nameof(model.Phone), "Applicant with the provided phone number already exists!");
                model.Towns = await selectOptionCollectionService.GetTowns();
                model.ProgrammingLanguages = await selectOptionCollectionService.GetProgrammingLanguages();
                model.Levels = await selectOptionCollectionService.GetLevels();
                return View(model);

            }

            if (!ModelState.IsValid)
            {
                model.Towns = await selectOptionCollectionService.GetTowns();
                model.ProgrammingLanguages = await selectOptionCollectionService.GetProgrammingLanguages();
                model.Levels = await selectOptionCollectionService.GetLevels();
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

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllApplicantsQueryModel queryModel)
        {

            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool IsCompanay = await this.companyService.CompanyExistsByUserId(userId);
            

            if (!IsCompanay)
            {
                this.TempData[ErrorMessage] = "Access denied! You have to be a recruiter!";

                return RedirectToAction("Index", "Home");

            }

            try
            {
                AllApplicantsFilteredAndPagedServiceModel serviceModel =
               await this.applicantService.All(queryModel);

                queryModel.Applicants = serviceModel.Applicants;
                queryModel.TotalApplicants = serviceModel.TotalApplicantsCount;
                queryModel.Levels = await selectOptionCollectionService.GetLevels();
                queryModel.Towns = await selectOptionCollectionService.GetTowns();
                queryModel.ProgrammingLanguages = await selectOptionCollectionService.GetProgrammingLanguages();

            }
            catch (Exception)
            {

                this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later or contact administrator!";
                return RedirectToAction("Index", "Home");
            }

            return View(queryModel);


        }

        public async Task <IActionResult> Details(string id)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool IsCompanay = await this.companyService.CompanyExistsByUserId(userId);

            if (!IsCompanay)
            {
                this.TempData[ErrorMessage] = "Access denied! You have to be a recruiter!";

                return RedirectToAction("Index", "Home");
            }


            var applicant = await applicantService.GetApplicantById(id);

            if (applicant == null)
            {
                this.TempData[ErrorMessage] = "Applicant with the provided id does not exist!";
                return RedirectToAction(nameof(All));

            }


            try
            {
                ApplicantDetailsViewModel model = await applicantService.GetDetailsOfApplicant(applicant, id);
                return View(model);

            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later or contact administrator!";
                return RedirectToAction(nameof(All));

            }



        }

      
    }
}
