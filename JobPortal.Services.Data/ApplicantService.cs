using JobPortal.Data;
using JobPortal.Data.Models;
using JobPortal.Services.Data.Interfaces;
using JobPortal.Web.ViewModels.Applicant;
using JobPortal.Web.ViewModels.JobOffer.Enums;
using JobPortal.Web.ViewModels.JobOffer;
using JopPortal.Services.Data.Models.Applicant;
using JopPortal.Services.Data.Models.JobOffer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.Common.EntityValidationConstants;
using Applicant = JobPortal.Data.Models.Applicant;

namespace JobPortal.Services.Data
{
    public class ApplicantService : IApplicantService
    {
        private readonly JobPortalDbContext dbContext;

        public ApplicantService(JobPortalDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<AllApplicantsFilteredAndPagedServiceModel> All(AllApplicantsQueryModel queryModel)
        {
            IQueryable<Applicant> applicantQuery = this.dbContext
               .Applicants
               .Where(jo => jo.IsDeleted == false)
               .AsQueryable();

           
            if (!string.IsNullOrEmpty(queryModel.Level))
            {
                applicantQuery = applicantQuery
                    .Where(j => j.Level.Name == queryModel.Level);
            }
            if (!string.IsNullOrEmpty(queryModel.ProgrammingLanguage))
            {
                applicantQuery = applicantQuery
                    .Where(j => j.ProgrammingLanguage.Name == queryModel.ProgrammingLanguage);
            }
            if (!string.IsNullOrEmpty(queryModel.Town))
            {
                applicantQuery = applicantQuery
                    .Where(j => j.Town.Name == queryModel.Town);
            }

            if (!string.IsNullOrEmpty(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                applicantQuery = applicantQuery
                    .Where(j => EF.Functions.Like(j.FirstName, wildCard) ||
                                EF.Functions.Like(j.LastName, wildCard));
            }

           

            IEnumerable<ApplicantAllViewModel> allApplicants = await applicantQuery

                .Skip((queryModel.CurrentPage - 1) * queryModel.ApplicantsPerPage)
                .Take(queryModel.ApplicantsPerPage)
                .Select(j => new ApplicantAllViewModel
                {
                    Id = j.Id.ToString(),
                    FirstName = j.FirstName,
                    LastName = j.LastName,
                    ProgrammingLanguage = j.ProgrammingLanguage.Name,
                    Level = j.Level.Name,
                    Town = j.Town.Name,
                    ImageUrl = j.ImgUrl,

                    

                })
                .ToArrayAsync();

            int totalApplicantsCount = applicantQuery.Count();


            return new AllApplicantsFilteredAndPagedServiceModel()
            {
                TotalApplicantsCount = totalApplicantsCount,
                Applicants = allApplicants,
            };
            
        }

      

        public async Task<bool> ApplicantExistsByPhoneNumber(string phoneNumber)
        {
            bool result = await dbContext
               .Applicants.AnyAsync(a => a.Phone == phoneNumber);

            return result;

        }

        public async Task<bool> ApplicantExistsByUserId(string userId)
        {

            bool isApplicantUser = await dbContext
               .Applicants
               .AnyAsync(a => a.ApplicationUserId.ToString() == userId);

            return isApplicantUser;
        }

        public async Task Create(BecomeApplicantFormModel model, string userId)
        {
            Applicant applicant = new Applicant()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone= model.Phone,
                ImgUrl = model.ImgUrl,
                TownId = model.TownId,
                LevelId = model.LevelId,
                ProgrammingLanguageId = model.ProgrammingLanguageId,
                ApplicationUserId = Guid.Parse(userId)

            };

            await dbContext.Applicants.AddAsync(applicant);
            await dbContext.SaveChangesAsync();

        }

        public async  Task<Applicant> GetApplicantByApplicationUserId(string applicationUserId)
        {
            Applicant? applicant = await dbContext.Applicants
                .FirstOrDefaultAsync(a => a.ApplicationUserId.ToString() == applicationUserId);

            return applicant;
            
        }

        public  async Task<Applicant> GetApplicantById(string applicantId)
        {
             Applicant? applicant = await dbContext.Applicants
                    .Include(a => a.ApplicantJobOffers)
                    .FirstOrDefaultAsync(a => a.Id.ToString() == applicantId);

            return applicant;
        }

        public async Task<ApplicantDetailsViewModel> GetDetailsOfApplicant(Applicant applicant, string applicantId)
        {
            
            var userId = applicant.ApplicationUserId;

            ApplicationUser? applicationUser = await this.dbContext.ApplicationUsers
                .FirstOrDefaultAsync(u => u.Id == userId);



            ApplicantDetailsViewModel modelDetails = new ApplicantDetailsViewModel()
            {
                Id = applicant.Id.ToString(),
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                ImageUrl = applicant.ImgUrl,
                
                Phone = applicant.Phone,
                Email = applicationUser!.Email,

                ApplicantJobOffers = applicant.ApplicantJobOffers,
                
            };


            return modelDetails;

        }

        public async Task<bool> IsApplicantAppliedForTheJob(Guid applicantId, Guid jobOfferId)
        {

            return await dbContext.ApplicantsJobOffers
                .AnyAsync(aj => aj.ApplicantId == applicantId && aj.JobOfferId == jobOfferId);

        }

        public async Task ApplicantApplyForOffer(Guid applicantId, Guid jobOfferId)
        {

            await dbContext.ApplicantsJobOffers
                .AddAsync(new ApplicantJobOffer()
                {
                    ApplicantId = applicantId,
                    JobOfferId = jobOfferId,
                });

            await dbContext.SaveChangesAsync();

        }
    }
}
