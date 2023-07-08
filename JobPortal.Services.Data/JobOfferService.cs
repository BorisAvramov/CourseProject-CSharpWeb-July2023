using JobPortal.Data;
using JobPortal.Data.Models;
using JobPortal.Services.Data.Interfaces;
using JobPortal.Web.ViewModels.JobOffer;
using JobPortal.Web.ViewModels.JobOffer.Enums;
using JopPortal.Services.Data.Models.JobOffer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                Description = model.Description,
                CreatedOn = DateTime.Now,


            };

            await dbContext.JobOffers.AddAsync(jobOffer);
            await dbContext.SaveChangesAsync();

        }

        public async Task<AllJobOffersFilteredAndPagedServiceModel> All(AllJobOffersQueryModel queryModel)
        {
            IQueryable<JobOffer> jobOfferQuery = this.dbContext
                .JobOffers
                .AsQueryable();

            if (!string.IsNullOrEmpty(queryModel.JobType))
            {
                jobOfferQuery = jobOfferQuery
                    .Where(j => j.JobType.TypeName == queryModel.JobType);
            }
            if (!string.IsNullOrEmpty(queryModel.Level))
            {
                jobOfferQuery = jobOfferQuery
                    .Where(j => j.Level.Name == queryModel.Level);
            }
            if (!string.IsNullOrEmpty(queryModel.ProgrammingLanguage))
            {
                jobOfferQuery = jobOfferQuery
                    .Where(j => j.ProgrammingLanguage.Name == queryModel.ProgrammingLanguage);
            }
            if (!string.IsNullOrEmpty(queryModel.Town))
            {
                jobOfferQuery = jobOfferQuery
                    .Where(j => j.Town.Name == queryModel.Town);
            }

            if (!string.IsNullOrEmpty(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                jobOfferQuery = jobOfferQuery
                    .Where(j => EF.Functions.Like(j.Name, wildCard)||
                                EF.Functions.Like(j.Description, wildCard));
            }

            jobOfferQuery = queryModel.JobOfferSorting switch
            {
                JobOfferSorting.Newest => jobOfferQuery
                    .OrderByDescending(j => j.CreatedOn),
                JobOfferSorting.Oldest => jobOfferQuery
                    .OrderBy(j => j.CreatedOn),
                JobOfferSorting.countOfApplicants => jobOfferQuery
                    .OrderByDescending(j => j.JobOfferApplicants.Count),
                _ => jobOfferQuery
                        .OrderByDescending(j => j.CreatedOn)
            };

            IEnumerable<JobOfferAllViewModel>  allJobOffers = await jobOfferQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.JobOffersPerPage)
                .Take(queryModel.JobOffersPerPage)
                .Select(j => new JobOfferAllViewModel
                {
                    Id = j.Id.ToString(),
                    Name = j.Name,
                    CreatedOn = j.CreatedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Description = j.Description,
                    ProgrammingLanguage = j.ProgrammingLanguage.Name,
                    Level = j.Level.Name,
                    JobType = j.JobType.TypeName,
                    Company = j.Company.Name,
                    Town = j.Town.Name,
                    CompanyImageUrl = j.Company.ImageUrl,
                   
                    JobOfferApplicantsCount = j.JobOfferApplicants.Count

                })
                .ToArrayAsync();

            int totalJobOffersCount = jobOfferQuery.Count();


            return new AllJobOffersFilteredAndPagedServiceModel()
            {
                TotalJobOffersCount = totalJobOffersCount,
                JobOffers = allJobOffers
            };
  
            }

        public async Task<IEnumerable<JobOfferAllViewModel>> AllByCompanyId(string userId)
        {
            Company? company = await companyService.GetCompanyByApplicationUserId(userId);

            IEnumerable<JobOfferAllViewModel> allCompanyJobOffers = await this.dbContext
                .JobOffers
                .Where(jo => jo.CompanyId == company.Id)
                .Select(jo => new JobOfferAllViewModel()
                {
                    Id = jo.Id.ToString(),
                    Name = jo.Name,
                    CreatedOn = jo.CreatedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Description = jo.Description,
                    ProgrammingLanguage = jo.ProgrammingLanguage.Name,
                    Town = jo.Town.Name,
                    Level = jo.Level.Name,
                    JobType = jo.JobType.TypeName,
                    Company = jo.Company.Name,
                    CompanyImageUrl = jo.Company.ImageUrl,

                    JobOfferApplicantsCount = jo.JobOfferApplicants.Count

                })
                .ToArrayAsync();

            return allCompanyJobOffers;

        }
    }
    }
