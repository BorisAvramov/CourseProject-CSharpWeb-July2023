using JobPortal.Data;
using JobPortal.Data.Models;
using JobPortal.Services.Data;
using JobPortal.Services.Data.Interfaces;
using JobPortal.Web.ViewModels.Applicant;
using Microsoft.EntityFrameworkCore;
using static JobPortal.Services.Tests.DatabaseSeeder;

namespace JobPortal.Services.Tests
{
    public class ApplicantServiceTests
    {
        private DbContextOptions<JobPortalDbContext> dbOptions;

        private JobPortalDbContext dbContext;

        private IApplicantService applicantService;

        [OneTimeSetUp]

        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<JobPortalDbContext>()
                .UseInMemoryDatabase("JobPortalInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new JobPortalDbContext(this.dbOptions);

            applicantService = new ApplicantService(this.dbContext);

            this.dbContext.Database.EnsureCreated();

            SeedDatabase(this.dbContext);
        }




        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task  ApplicantExistsByUserIdReturnsTrue()
        {
            string userId = ApplicantUserPesho.Id.ToString();

            bool result = await applicantService.ApplicantExistsByUserId(userId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ApplicantExistsByUserIdReturnsFalse()
        {
            string userId = CompanyUserSoftUni.Id.ToString();

            bool result = await applicantService.ApplicantExistsByUserId(userId);

            Assert.IsFalse(result);
        }




        [Test]
        public async Task ApplicantExistsByPhoneNumberReturnsTrue()
        {
            string phone = applicantPesho.Phone;

            bool result = await applicantService.ApplicantExistsByPhoneNumber(phone);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ApplicantExistsByPhoneNumberReturnsFalse()
        {
            string phone = CompanyUserSoftUni.PhoneNumber;

            bool result = await applicantService.ApplicantExistsByPhoneNumber(phone);

            Assert.IsFalse(result);
        }



        [Test]
        public async Task GetApplicantById_Positive()
        {
            var applicantUser =  await applicantService.GetApplicantById(applicantPesho.Id.ToString());


            Assert.That(applicantPesho.ApplicationUser.Id, Is.EqualTo(ApplicantUserPesho.Id));
            Assert.That(applicantPesho.FirstName, Is.EqualTo(applicantUser.FirstName));
            Assert.That(applicantPesho.LastName, Is.EqualTo(applicantUser.LastName));
        }

        [Test]
        public async Task GetApplicantById_ReturnNull()
        {
            var applicantUser = await applicantService.GetApplicantById(CompanyUserSoftUni.Id.ToString());


            Assert.That(applicantUser,Is.Null);
        }


        [Test]
        public async Task GetApplicantByApplicationUserId_Positive()
        {
            var applicantUser = await applicantService.GetApplicantByApplicationUserId(ApplicantUserPesho.Id.ToString());


            Assert.That(applicantPesho.ApplicationUser.Id, Is.EqualTo(ApplicantUserPesho.Id));
            Assert.That(applicantPesho.FirstName, Is.EqualTo(applicantUser.FirstName));

            Assert.That(applicantPesho.LastName, Is.EqualTo(applicantUser.LastName));

        }

        [Test]
        public async Task GetApplicantByApplicationUserId_ReturnNull()
        {
            var applicantUser = await applicantService.GetApplicantByApplicationUserId(CompanyUserSoftUni.Id.ToString());

            Assert.That(applicantUser, Is.Null);
        }


        [Test]
        public async Task IsApplicantAppliedForTheJob_ReturnsTrue()
        {
            bool result = await applicantService.IsApplicantAppliedForTheJob(applicantPesho.Id, jobOfferCSharp.Id);

            Assert.IsTrue(result);


        }

        [Test]
        public async Task IsApplicantAppliedForTheJob_ReturnsFalse()
        {
            bool result = await applicantService.IsApplicantAppliedForTheJob(applicantAni.Id, jobOfferCSharp.Id);

            Assert.IsFalse(result);


        }

        [Test]
        public async Task ApplicantApplyForOffer_Positive()
        {

            await applicantService.ApplicantApplyForOffer(applicantBoris.Id, jobOfferCSharp.Id);

            ApplicantJobOffer? applicantJobOffer = await dbContext
                .ApplicantsJobOffers
                .FirstOrDefaultAsync(aj => aj.ApplicantId == applicantBoris.Id && aj.JobOfferId == jobOfferCSharp.Id);


            Assert.IsTrue(dbContext.ApplicantsJobOffers.Contains(applicantJobOffer));

        }


        

             [Test]
        public async Task GetDetailsOfApplicant()
        {

            ApplicantDetailsViewModel detailsViewModelResult = await applicantService.GetDetailsOfApplicant(applicantBoris, applicantBoris.Id.ToString());

            ApplicantDetailsViewModel detailsViewModelExpected = new ApplicantDetailsViewModel()
            {
                Id = applicantBoris.Id.ToString(),
                FirstName = "Boris",
                LastName = "Avramov",
                ImageUrl = "https://img.icons8.com/?size=96&id=9pUkuUjlk0Qa&format=png",
                Phone = "+359666666666",
                Email = "bobiTheApplicant@applicants.com",
                ApplicantJobOffers = applicantBoris.ApplicantJobOffers
            };

         

            Assert.AreEqual(detailsViewModelExpected.Id, detailsViewModelResult.Id);
            Assert.AreEqual(detailsViewModelExpected.FirstName, detailsViewModelResult.FirstName);
            Assert.AreEqual(detailsViewModelExpected.LastName, detailsViewModelResult.LastName);
            Assert.AreEqual(detailsViewModelExpected.ImageUrl, detailsViewModelResult.ImageUrl);
            Assert.AreEqual(detailsViewModelExpected.Phone, detailsViewModelResult.Phone);
            Assert.AreEqual(detailsViewModelExpected.Email, detailsViewModelResult.Email);
            Assert.AreEqual(detailsViewModelExpected.ApplicantJobOffers, detailsViewModelResult.ApplicantJobOffers);

        }

        [Test]
        public async Task BecomeApplicant()
        {

            BecomeApplicantFormModel becomeModel = new BecomeApplicantFormModel()
            {
                FirstName = "Misho",
                LastName = "Petrov",
                Phone = "+359999999999",
                ImgUrl = "https://cdn-icons-png.flaticon.com/512/4086/4086679.png",
                TownId = 1,
                LevelId = 2,
                ProgrammingLanguageId = 3,

            };

            await applicantService.Create(becomeModel, FutureapplicantUserMIsho.Id.ToString());

            Applicant? applicantMIsho = await dbContext
                .Applicants
                .FirstOrDefaultAsync(a => a.ApplicationUserId == FutureapplicantUserMIsho.Id);


            Assert.IsTrue(dbContext.Applicants.Contains(applicantMIsho));

        }


        [OneTimeTearDown]

        public void OneTimeTearDown()
        {
            this.dbContext.Database.EnsureDeleted();
        }
    }
}