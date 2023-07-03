using JobPortal.Data;
using JobPortal.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Services.Data
{
    public class CompanyService : ICompanyService
    {
        private readonly JobPortalDbContext dbContext;

        public CompanyService(JobPortalDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<bool> CompanyExistsByUserId(string userId)
        {
            bool isCompanyUser = await dbContext
                .Companies
                .AnyAsync(c => c.ApplicationUserId.ToString() == userId);

            return isCompanyUser;
        }
    }
}