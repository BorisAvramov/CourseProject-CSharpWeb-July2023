using JobPortal.Data.Models;
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
        private readonly IApplicantService applicantService;
        private readonly ISelectOptionCollectionService selectOptionCollectionService;


        public JobOfferController(ICompanyService _companyService, IJobOfferService _jobOfferService, ISelectOptionCollectionService _selectOptionCollectionService, IApplicantService _applicantService)
        {
            this.companyService = _companyService;
            this.jobOfferService = _jobOfferService;
            this.applicantService = _applicantService;
            this.selectOptionCollectionService = _selectOptionCollectionService;


        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllJobOffersQueryModel queryModel)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool IsCompanay = await this.companyService.CompanyExistsByUserId(userId);
            bool IsApplicant = await this.applicantService.ApplicantExistsByUserId(userId);

            if (!IsCompanay && !IsApplicant)
            {
                this.TempData[ErrorMessage] = "Access denied! You have to be a recruiter or applicant!";

                return RedirectToAction("Index", "Home");

            }

            try
            {
                AllJobOffersFilteredAndPagedServiceModel serviceModel =
               await this.jobOfferService.All(queryModel);

                queryModel.JobOffers = serviceModel.JobOffers;
                queryModel.TotalJobOffers = serviceModel.TotalJobOffersCount;
                queryModel.JobTypes = await selectOptionCollectionService.GetJobTypes();
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
                return RedirectToAction(nameof(All));


            }



            return RedirectToAction(nameof(CompanyJobOffers));
        }

        [HttpGet]

        public async Task<IActionResult> CompanyJobOffers()
        {
            List<JobOfferAllViewModel> companyJobOffers = new List<JobOfferAllViewModel>();
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool IsCompanay = await this.companyService.CompanyExistsByUserId(userId);

            if (!IsCompanay)
            {
                this.TempData[ErrorMessage] = "Access denied! You have to be a recruiter!";

                return RedirectToAction(nameof(All));
            }

            try
            {
                companyJobOffers.AddRange(await jobOfferService.AllByCompanyId(userId!));
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later or contact administrator!";
                return RedirectToAction(nameof(All));
                
            }

            

            return this.View(companyJobOffers);


        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool IsCompanay = await this.companyService.CompanyExistsByUserId(userId);
            bool IsApplicant = await this.applicantService.ApplicantExistsByUserId(userId);

            if (!IsCompanay && !IsApplicant)
            {
                this.TempData[ErrorMessage] = "Access denied! You have to be a recruiter or applicant!";

                return RedirectToAction("Index", "Home");

            }


            var jobOffer = await jobOfferService.GetJobOfferById(id);

            if (jobOffer == null)
            {
                this.TempData[ErrorMessage] = "Job Offer with the provided id does not exist!";
                return RedirectToAction(nameof(All));

            }


            try
            {
                JobOfferDetailsViewModel model = await jobOfferService.GetDetailsOfJobOffer(jobOffer, id);
                return View(model);

            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later or contact administrator!";
                return RedirectToAction(nameof(All));

            }


        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool IsCompanay = await this.companyService.CompanyExistsByUserId(userId);

            var jobOffer = await jobOfferService.GetJobOfferById(id);
            var company = await companyService.GetCompanyByApplicationUserId(userId);
            if (!IsCompanay)
            {
                this.TempData[ErrorMessage] = "Access denied! You have to be a recruiter!";
                return RedirectToAction("Index", "Home");
            }
            if (jobOffer == null)
            {
                this.TempData[ErrorMessage] = "Job Offer with the provided id does not exist!";
                return RedirectToAction(nameof(CompanyJobOffers));

            }
            

            if (jobOffer.CompanyId != company.Id)
            {
                this.TempData[ErrorMessage] = "You are not creator of this Job Offer!";
                return RedirectToAction(nameof(CompanyJobOffers));

            }

            try
            {
                await jobOfferService.Delete(id, userId);
                this.TempData[SuccessMessage] = "Job offer successfully deleted!";
            }
            catch (Exception)
            {

                this.TempData[ErrorMessage] = "Unexpected error occurred while deleting job offer! Please try again later or contact administrator!";
            }

            return RedirectToAction(nameof(CompanyJobOffers));



        }

        [HttpGet]

        public async Task<IActionResult> Edit(string id)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool IsCompanay = await this.companyService.CompanyExistsByUserId(userId);

            var jobOffer = await jobOfferService.GetJobOfferById(id);
            var company = await companyService.GetCompanyByApplicationUserId(userId);



            if (!IsCompanay)
            {
                this.TempData[ErrorMessage] = "Access denied! You have to be a recruiter!";

                return RedirectToAction("Index", "Home");

            }
            if (jobOffer == null)
            {
                this.TempData[ErrorMessage] = "Job Offer with the provided id does not exist!";
                return RedirectToAction(nameof(CompanyJobOffers));
            }

            if (jobOffer.CompanyId != company.Id)
            {
                this.TempData[ErrorMessage] = "You are not creator of this Job Offer!";
                return RedirectToAction(nameof(CompanyJobOffers));

            }

            JobOfferEditFormViewModel model = new JobOfferEditFormViewModel()
            {
                Name = jobOffer.Name,
                Description = jobOffer.Description,
                TownId = jobOffer.TownId,
                ProgrammingLanguageId = jobOffer.ProgrammingLanguageId,
                LevelId = jobOffer.LevelId,
                JobTypeId = jobOffer.JobTypeId,


                Towns = await selectOptionCollectionService.GetTowns(),
                ProgrammingLanguages = await selectOptionCollectionService.GetProgrammingLanguages(),
                Levels = await selectOptionCollectionService.GetLevels(),
                JobTypes = await selectOptionCollectionService.GetJobTypes(),
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, JobOfferEditFormViewModel model)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var jobOffer = await jobOfferService.GetJobOfferById(id);

            bool IsCompanay = await this.companyService.CompanyExistsByUserId(userId);

            if (!IsCompanay)
            {
                this.TempData[ErrorMessage] = "Access denied! You have to be a recruiter!";

                return RedirectToAction("Index", "Home");
            }
            if (jobOffer == null)
            {
                this.TempData[ErrorMessage] = "Job Offer with the provided id does not exist!";
                return RedirectToAction(nameof(CompanyJobOffers));
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


                await jobOfferService.Edit(jobOffer, model);
                this.TempData[SuccessMessage] = "Job offer successfully edited!";

                //await roleService.CreateRole("applicant");
                //await roleService.AddRoleToApplicationUser(userId, "applicant");

            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred while editing job offer! Please try again later or contact administrator!";
 
            }



            return RedirectToAction(nameof(CompanyJobOffers));
        }

        [HttpPost]
        public async Task<IActionResult> Apply(string id)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool IsApplicant = await this.applicantService.ApplicantExistsByUserId(userId);


            if (!IsApplicant)
            {
                this.TempData[ErrorMessage] = "Access denied! You have to be an applicant!";

                return RedirectToAction("Index", "Home");
            }

            Applicant applicant = await applicantService.GetApplicantByApplicationUserId(userId);
            Guid applicatnId = applicant.Id;

            bool AlreadyAppliedForTheJob = await applicantService.IsApplicantAppliedForTheJob(applicatnId, Guid.Parse(id));

            if (AlreadyAppliedForTheJob)
            {
                this.TempData[ErrorMessage] = "You have already applied for the job!";
                return RedirectToAction("All", "JobOffer");

            }


            try
            {
                await applicantService.ApplicantApplyForOffer(applicatnId, Guid.Parse(id));
                this.TempData[SuccessMessage] = "You have successfully applied for the job!";

            }
            catch (Exception)
            {

                this.TempData[ErrorMessage] = "Unexpected error occurred while applying for the job! Please try again later or contact administrator!";

            }
            return RedirectToAction("All", "JobOffer");

        }
    }
}

