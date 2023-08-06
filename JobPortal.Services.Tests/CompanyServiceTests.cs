using JobPortal.Data;
using JobPortal.Data.Models;
using JobPortal.Services.Data;
using JobPortal.Services.Data.Interfaces;
using JobPortal.Web.ViewModels.Applicant;
using JobPortal.Web.ViewModels.Company;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static JobPortal.Services.Tests.DatabaseSeeder;

namespace JobPortal.Services.Tests
{
    public class CompanyServiceTests
    {

        private DbContextOptions<JobPortalDbContext> dbOptions;

        private JobPortalDbContext dbContext;

        private ICompanyService companyService;


        [OneTimeSetUp]

        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<JobPortalDbContext>()
                .UseInMemoryDatabase("JobPortalInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new JobPortalDbContext(this.dbOptions);

            companyService = new CompanyService(this.dbContext);

            this.dbContext.Database.EnsureCreated();

            SeedDatabase(this.dbContext);
        }

        [SetUp]
        public void Setup()
        {
        }

        
        [Test]
        
        public async Task CompanyExistsByUserIdReturnsTrue()
        {
            string userId = CompanyUserSoftUni.Id.ToString();

            bool result = await companyService.CompanyExistsByUserId(userId);

            Assert.IsTrue(result);
        }

        [Test]

        public async Task CompanyExistsByUserIdReturnsFalse()
        {
            string userId = ApplicantUserBoris.Id.ToString();

            bool result = await companyService.CompanyExistsByUserId(userId);

            Assert.IsFalse(result);
        }


        [Test]
        public async Task CompanyExistsByPhoneNumberReturnsTrue()
        {
            string phone = companySoftUni.Phone;

            bool result = await companyService.CompanyExistsByPhoneNumber(phone);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task CompanyExistsByPhoneNumberReturnsFalse()
        {
            string phone = applicantPesho.Phone;

            bool result = await companyService.CompanyExistsByPhoneNumber(phone);

            Assert.IsFalse(result);
        }


        [Test]
        public async Task GetCompanyById_Positive()
        {
            var companyUser = await companyService.GetCompanyByApplicationUserId(CompanyUserSoftUni.Id.ToString());


            Assert.That(companySoftUni.ApplicationUser.Id, Is.EqualTo(CompanyUserSoftUni.Id));
            Assert.That(companySoftUni.Name, Is.EqualTo(companyUser.Name));
            Assert.That(companySoftUni.Description, Is.EqualTo(companyUser.Description));
        }

        [Test]
        public async Task GetApplicantById_ReturnNull()
        {
            var applicantUser = await companyService.GetCompanyByApplicationUserId(ApplicantUserBoris.Id.ToString());


            Assert.That(applicantUser, Is.Null);
        }

        [Test]
        public async Task BecomeCompany()
        {

            BecomeRecruiterFormModel becomeModel = new BecomeRecruiterFormModel()
            {
               

                Name = "Robert Bosch GmbH",
                Phone = "+359333333333",
                Description = "The Bosch Group is a leading global supplier of technology and services",
                Address = "51b Cherni Vrah Blvd FPI Business Center Sofia",
                ImageUrl = "https://cdn-s3.angro.bg/media/magiccart/shopbrand/brand/b/o/bosch.jpg",
                //ApplicationUserId = Guid.Parse(userId)

            };

            await companyService.Create(becomeModel, FutureCompanyUserBosch.Id.ToString());

            Company? companyBosch = await dbContext
                .Companies
                .FirstOrDefaultAsync(a => a.ApplicationUserId == FutureCompanyUserBosch.Id);


            Assert.IsTrue(dbContext.Companies.Contains(companyBosch));

        }


        [Test]

        public  void IsCompanyOwner_ReturnsTrue()
        {

            bool isCompanyOwner =  companyService.IsCompanyOwner(companySoftUni, jobOfferCSharp );

            Assert.IsTrue(isCompanyOwner);

        }

        [Test]

        public void IsCompanyOwner_ReturnsFalse()
        {
            Company company = new Company()
            {
                Id = new Guid(),
                Name = "DXC Technology",
                ImageUrl = "https://dxc.com/content/dam/dxc/projects/dxc-com/us/images/about-us/newsroom/logos-for-media/vertical/DXC%20Logo_Purple+Black%20RGB.png",
                Phone = "+359222222222",
                Address = "258 Vladislav Varnenchik Blvd., 9009 Western Industrial Zone, Varna",
                Description = "We are an IT services company using the power of technology to build better futures for our customers, colleagues, environment and communities.",



            };


            bool isCompanyOwner = companyService.IsCompanyOwner(company, jobOfferCSharp);

            Assert.IsFalse(isCompanyOwner);

        }

        [OneTimeTearDown]

        public void OneTimeTearDown()
        {
            this.dbContext.Database.EnsureDeleted();
        }

    }
}
