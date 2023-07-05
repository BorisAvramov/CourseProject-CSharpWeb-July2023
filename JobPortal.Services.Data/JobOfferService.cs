using JobPortal.Data;
using JobPortal.Data.Models;
using JobPortal.Services.Data.Interfaces;
using JobPortal.Web.ViewModels.JobOffer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Data
{
    public class JobOfferService : IJobOfferService
    {
        private readonly JobPortalDbContext dbContext;

        private readonly ICompanyService companyService;

        public JobOfferService(JobPortalDbContext _dbContext, ICompanyService _companyService)
        {
            this.dbContext = _dbContext;
            this.companyService = _companyService;
        }

        public  async Task AddJobOffer(JobOfferAddFormViewModel model, string userId)
        {

            Company? company = await companyService.GetCompanyByApplicationUserId(userId);

            JobOffer jobOffer = new JobOffer()
            {
                Name = model.Name,
                TownId = model.TownId,
                LevelId = model.LevelId,
                ProgrammingLanguageId = model.ProgrammingLanguageId,
                JobTypeId = model.JobTypeId,
                CompanyId = company.Id,
                Description = model.Description


            };

            await dbContext.JobOffers.AddAsync(jobOffer);
            await dbContext.SaveChangesAsync();

        }
    }
}
