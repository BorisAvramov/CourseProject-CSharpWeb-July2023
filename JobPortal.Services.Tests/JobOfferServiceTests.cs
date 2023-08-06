using JobPortal.Data;
using JobPortal.Data.Models;
using JobPortal.Services.Data;
using JobPortal.Services.Data.Interfaces;
using JobPortal.Web.ViewModels.Applicant;
using JobPortal.Web.ViewModels.JobOffer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static JobPortal.Services.Tests.DatabaseSeeder;


namespace JobPortal.Services.Tests
{
    public class JobOfferServiceTests
    {

        private DbContextOptions<JobPortalDbContext> dbOptions;

        private JobPortalDbContext dbContext;

        private ICompanyService companyService;

        private IJobOfferService jobOfferService;

        private IApplicantService applicantService;


        [OneTimeSetUp]

        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<JobPortalDbContext>()
                .UseInMemoryDatabase("JobPortalInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new JobPortalDbContext(this.dbOptions);

            companyService = new CompanyService(this.dbContext);
            applicantService = new ApplicantService(this.dbContext);

            jobOfferService = new JobOfferService(this.dbContext, companyService);

            //For correct testing you have to comment Seed data methotds (HasData()) in Entity Configuration Classes


            this.dbContext.Database.EnsureCreated();

            SeedDatabase(this.dbContext);
        }

        [Test]
        public async Task AllFilteredByLevel()
        {
            AllJobOffersQueryModel queryModel = new AllJobOffersQueryModel()
            {
                Level = Senior.Name
            };

            var result = await jobOfferService.All(queryModel);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.JobOffers.Any(a => a.Name == "Front-End Developer with React/Angular" 
                && a.Description == "As a Senior Front-End Developer, you can be а part of many impactful projects in the public sector and therefore make a true difference to the world. From developing a web application that enables a revolutionary way to attend a driver license exam to providing a new information system that could rationalize clinical studies, patients’ clinical data and prescriptions monitoring."));
            Assert.That(!result.JobOffers.Any(a => a.Name == "C# .NET Developer"));

        }


      


        [Test]
        public async Task GetJobOfferById()
        {
            var jobOffer = await jobOfferService.GetJobOfferById(jobOfferCSharp.Id.ToString());


            Assert.That(jobOffer.Id, Is.EqualTo(jobOfferCSharp.Id));
            
        }

        [Test]
        public async Task GetApplicantById_ReturnNull()
        {
            var jobOffer = await jobOfferService.GetJobOfferById("9b23c76b-2387-4e93-ba82-13d26bb0c5fe");


            Assert.That(jobOffer, Is.Null);
        }

        [Test]
        public async Task GetDetailsOfJobOffer()
        {

            JobOfferDetailsViewModel detailsViewModelResult = await jobOfferService.GetDetailsOfJobOffer(jobOfferCSharp, jobOfferCSharp.Id.ToString());

            JobOfferDetailsViewModel detailsViewModelExpected = new JobOfferDetailsViewModel()
            {
                Id = jobOfferCSharp.Id.ToString(),
                CompanyImageUrl = companySoftUni.ImageUrl,
                Name = jobOfferCSharp.Name,
                Description = jobOfferCSharp.Description,
                CompanyId = companySoftUni.Id.ToString(),
                CompanyPhone = companySoftUni.Phone,                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
                CompanyEmail = CompanyUserSoftUni.Email

            };

          

            Assert.AreEqual(detailsViewModelExpected.Id, detailsViewModelResult.Id);
            Assert.AreEqual(detailsViewModelExpected.CompanyImageUrl, detailsViewModelResult.CompanyImageUrl);
            Assert.AreEqual(detailsViewModelExpected.Name, detailsViewModelResult.Name);
            Assert.AreEqual(detailsViewModelExpected.Description, detailsViewModelResult.Description);
            Assert.AreEqual(detailsViewModelExpected.CompanyId, detailsViewModelResult.CompanyId);
            Assert.AreEqual(detailsViewModelExpected.CompanyPhone, detailsViewModelResult.CompanyPhone);
            Assert.AreEqual(detailsViewModelExpected.CompanyEmail, detailsViewModelResult.CompanyEmail);

        }

        [Test]

        public async Task Edit()
        {

            Assert.That(jobOfferCSharp.Name, Is.EqualTo("C# .NET Developer"));

            JobOfferEditFormViewModel editModel = new JobOfferEditFormViewModel()
            {

                Name = "C# .NET Developer!!!"

          

            };

            await jobOfferService.Edit(jobOfferCSharp, editModel);

            Assert.That(jobOfferCSharp.Name, Is.EqualTo("C# .NET Developer!!!"));

        }


        [Test]

        public async Task Delete()
        {
            Assert.IsFalse(jobOfferCSharp.IsDeleted);

            
            await jobOfferService.Delete(jobOfferCSharp.Id.ToString(), companySoftUni.Id.ToString());


            Assert.IsTrue(jobOfferCSharp.IsDeleted);

        }

        [Test]

        public async Task AllByCompanyId()
        {
          var all =   await jobOfferService.AllByCompanyId(CompanyUserBosch.Id.ToString());


            Assert.That(all.Count(), Is.EqualTo(1));
            Assert.That(all.Any(j => j.Name == "Front-End Developer with React/Angular"));


        }

        [Test]

        public async Task AllByApplicantId()


        {

            await applicantService.ApplicantApplyForOffer(applicantBoris.Id, jobOfferCSharp.Id);

            var all = await jobOfferService.AllByApplicantId(applicantBoris.Id.ToString());


            Assert.That(all.Count(), Is.EqualTo(1));
            Assert.That(all.Any(j => j.Name == "C# .NET Developer"));


        }

        [Test]

        public async Task AddJobOffer()
        {
            string userId = CompanyUserSoftUni.Id.ToString();

            JobOfferAddFormViewModel model = new JobOfferAddFormViewModel()
            {


                Name = "Front-End Developer with React/Angular",
                TownId = Sofia.Id,
                LevelId = Senior.Id,
                ProgrammingLanguageId = JavaScript.Id,
                JobTypeId = Remote.Id,
                Description = "As a Senior Front-End Developer, you can be а part of many impactful projects in the public sector and therefore make a true difference to the world. From developing a web application that enables a revolutionary way to attend a driver license exam to providing a new information system that could rationalize clinical studies, patients’ clinical data and prescriptions monitoring.",



            };

            await jobOfferService.AddJobOffer(model, userId);


            Assert.That(dbContext.JobOffers
                .Any(j => j.Description == "As a Senior Front-End Developer, you can be а part of many impactful projects in the public sector and therefore make a true difference to the world. From developing a web application that enables a revolutionary way to attend a driver license exam to providing a new information system that could rationalize clinical studies, patients’ clinical data and prescriptions monitoring."
                && j.Company == companySoftUni));


        }

        [OneTimeTearDown]

        public void OneTimeTearDown()
        {
            this.dbContext.Database.EnsureDeleted();
        }
    }
}
