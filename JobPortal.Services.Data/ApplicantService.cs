using JobPortal.Data;
using JobPortal.Data.Models;
using JobPortal.Services.Data.Interfaces;
using JobPortal.Web.ViewModels.Applicant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Data
{
    public class ApplicantService : IApplicantService
    {
        private readonly JobPortalDbContext dbContext;

        public ApplicantService(JobPortalDbContext _dbContext)
        {
            this.dbContext = _dbContext;
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

      
    }
}
