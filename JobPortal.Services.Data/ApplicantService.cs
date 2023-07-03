using JobPortal.Data;
using JobPortal.Services.Data.Interfaces;
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

        public async Task<bool> ApplicantExistsByUserId(string userId)
        {

            bool isApplicantUser = await dbContext
               .Applicants
               .AnyAsync(a => a.ApplicationUserId.ToString() == userId);

            return isApplicantUser;
        }
    }
}
