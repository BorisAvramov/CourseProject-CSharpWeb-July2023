using JobPortal.Data;
using JobPortal.Data.Models;
using JobPortal.Services.Data.Interfaces;
using JobPortal.Web.ViewModels.Company;
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

        public async Task<bool> CompanyExistsByPhoneNumber(string phoneNumber)
        {
            bool result = await dbContext
                .Companies.AnyAsync(c => c.Phone == phoneNumber);

            return result;

        }

        public async Task<bool> CompanyExistsByUserId(string userId)
        {
            bool isCompanyUser = await dbContext
                .Companies
                .AnyAsync(c => c.ApplicationUserId.ToString() == userId);

            return isCompanyUser;
        }

        

        public async Task Create(BecomeRecruiterFormModel model, string userId)
        {
            Company company = new Company()
            {
                Name = model.Name,
                Phone = model.Phone,
                Description = model.Description,
                Address = model.Address,
                ImageUrl= model.ImageUrl,
                ApplicationUserId = Guid.Parse(userId)

            };

            await dbContext.Companies.AddAsync(company);
            await dbContext.SaveChangesAsync();


        }

        public async Task<Company> GetCompanyByApplicationUserId(string userId)
        {
             Company? company  = await dbContext
                .Companies
                .FirstOrDefaultAsync(c => c.ApplicationUserId.ToString() == userId);

            return company!;



        }

        public  bool IsCompanyOwner(Company company, JobOffer jobOffer)
        {
            bool isCompanyOwner = jobOffer.CompanyId == company.Id;

            return isCompanyOwner;
        }
    }
}