using JobPortal.Services.Data;
using JobPortal.Services.Data.Interfaces;
using JobPortal.Web.ViewModels.Applicant;
using JobPortal.Web.ViewModels.JobOffer;
using JopPortal.Services.Data.Models.JobOffer;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllJobOffersQueryModel queryModel)
        {
             
            AllJobOffersFilteredAndPagedServiceModel serviceModel =
                await this.jobOfferService.All(queryModel);

            queryModel.JobOffers = serviceModel.JobOffers;
            queryModel.TotalJobOffers = serviceModel.TotalJobOffersCount;
            queryModel.JobTypes = await selectOptionCollectionService.GetJobTypes();
            queryModel.Levels = await selectOptionCollectionService.GetLevels();
            queryModel.Towns = await selectOptionCollectionService.GetTowns();
            queryModel.ProgrammingLanguages = await selectOptionCollectionService.GetProgrammingLanguages();
            return View(queryModel);
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
                model.Towns = await selectOptionCollectionService.GetTowns();
                model.ProgrammingLanguages = await selectOptionCollectionService.GetProgrammingLanguages();
                model.Levels = await selectOptionCollectionService.GetLevels();
                model.JobTypes = await selectOptionCollectionService.GetJobTypes();

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



            return RedirectToAction(nameof(All));
        }
    }
}
