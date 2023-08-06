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
    public class SelectOptionCollectionServiceTests
    {
        private DbContextOptions<JobPortalDbContext> dbOptions;

        private JobPortalDbContext dbContext;

        private ISelectOptionCollectionService selectOptionCollectionService;


        [OneTimeSetUp]

        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<JobPortalDbContext>()
                .UseInMemoryDatabase("JobPortalInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new JobPortalDbContext(this.dbOptions);

            selectOptionCollectionService = new SelectOptionCollectionService(dbContext);


            this.dbContext.Database.EnsureCreated();

            SeedDatabase(this.dbContext);
        }



        [Test]

        public async Task GetJobTypes()
        {

            var jobTypes = await  selectOptionCollectionService.GetJobTypes();


            Assert.AreEqual(6, jobTypes.Count());
            Assert.That(jobTypes.Any(jt => jt.TypeName == "Remote"));
            Assert.That(jobTypes.Any(jt => jt.TypeName == "Hybrid"));
            Assert.That(jobTypes.Any(jt => jt.TypeName == "Office"));



        }

        [Test]

        public async Task GetLevels()
        {

            var Levels = await selectOptionCollectionService.GetLevels();


            Assert.AreEqual(6, Levels.Count());
            Assert.That(Levels.Any(jt => jt.Name == "Mid"));
            Assert.That(Levels.Any(jt => jt.Name == "Junior"));
            Assert.That(Levels.Any(jt => jt.Name == "Senior"));



        }

        [Test]

        public async Task GetProgrammingLanguages()
        {

            var languages = await selectOptionCollectionService.GetProgrammingLanguages();


            Assert.AreEqual(6, languages.Count());
            Assert.That(languages.Any(jt => jt.Name == "JavaScript"));
            Assert.That(languages.Any(jt => jt.Name == "CSharp"));
            Assert.That(languages.Any(jt => jt.Name == "PHP"));



        }

        [Test]

        public async Task GetTowns()
        {

            var towns = await selectOptionCollectionService.GetTowns();


            Assert.AreEqual(8, towns.Count());
            Assert.That(towns.Any(jt => jt.Name == "Sofia"));
            Assert.That(towns.Any(jt => jt.Name == "Ruse"));
            Assert.That(towns.Any(jt => jt.Name == "Varna"));



        }
    }
}
