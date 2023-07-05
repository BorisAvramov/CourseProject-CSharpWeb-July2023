using JobPortal.Services.Data;
using JobPortal.Services.Data.Interfaces;
using JobPortal.Web.ViewModels.Applicant;
using JobPortal.Web.ViewModels.JobOffer;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using static JobPortal.Common.NotificationMessageConstants;

namespace JobPortal.Web.Controllers
{
    public class JobOfferController : BaseController
    {
        private readonly ICompanyService companyService;
        private readonly IJobOfferService jobOfferService;
        private readonly ISelectOptionCollectionService selectOptionCollectionService;


        public JobOfferController(ICompanyService _companyService, IJobOfferService _jobOfferService, ISelectOptionCollectionService _selectOptionCollectionService)
        {
            this.companyService = _companyService;
            this.jobOfferService = _jobOfferService;
            this.selectOptionCollectionService = _selectOptionCollectionService;


        }



        [HttpGet]
        public async Task<IActionResult> Add()
        {

            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool IsCompanay = await this.companyService.CompanyExistsByUserId(userId);

            if (!IsCompanay)
            {
                this.TempData[ErrorMessage] = "Access denied! You have to be a recruiter!";

                return RedirectToAction("Index", "Home");
            }

            JobOfferAddFormViewModel model = new JobOfferAddFormViewModel()
            {
                Towns = await selectOptionCollectionService.GetTowns(),
                ProgrammingLanguages = await selectOptionCollectionService.GetProgrammingLanguages(),
                Levels = await selectOptionCollectionService.GetLevels(),
                JobTypes = await selectOptionCollectionService.GetJobTypes(),
            };


            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> Add(JobOfferAddFormViewModel model)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool IsCompanay = await this.companyService.CompanyExistsByUserId(userId);

            if (!IsCompanay)
            {
                this.TempData[ErrorMessage] = "Access denied! You have to be a recruiter!";

                return RedirectToAction("Index", "Home");
            }


          
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {

               
                await jobOfferService.AddJobOffer(model, userId);
                this.TempData[SuccessMessage] = "Job offer successfully added!";

                //await roleService.CreateRole("applicant");
                //await roleService.AddRoleToApplicationUser(userId, "applicant");

            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred while adding new job offer! Please try again later or contact administrator!";
                return RedirectToAction("Index", "Home");


            }



            return RedirectToAction("Index", "Home");
        }
    }
}
