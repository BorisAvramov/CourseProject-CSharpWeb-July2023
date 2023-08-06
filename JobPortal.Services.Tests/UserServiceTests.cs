using JobPortal.Data;
using JobPortal.Services.Data;
using JobPortal.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static JobPortal.Services.Tests.DatabaseSeeder;


namespace JobPortal.Services.Tests
{
    public class UserServiceTests
    {


        private DbContextOptions<JobPortalDbContext> dbOptions;

        private JobPortalDbContext dbContext;

        private ICompanyService companyService;

        private IApplicantService applicantService;


        private IUserService userService;

        [OneTimeSetUp]

        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<JobPortalDbContext>()
                .UseInMemoryDatabase("JobPortalInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new JobPortalDbContext(this.dbOptions);

            applicantService = new ApplicantService(this.dbContext);

            companyService = new CompanyService(this.dbContext);

            userService = new UserService(this.dbContext, applicantService, companyService);


            

            this.dbContext.Database.EnsureCreated();

            SeedDatabase(this.dbContext);
        }

        [Test]

        public async Task GetFullNameById()
        {

            var fullName = await userService.GetFullNameById(ApplicantUserBoris.Id.ToString());


            Assert.AreEqual("Boris Avramov", fullName);


        }

        [Test]

        public async Task All()
        {

            var all = await userService.All(ApplicantUserBoris.Id.ToString());


            Assert.AreEqual(6, all.Count());


        }

        [OneTimeTearDown]

        public void OneTimeTearDown()
        {
            this.dbContext.Database.EnsureDeleted();
        }


    }
}
