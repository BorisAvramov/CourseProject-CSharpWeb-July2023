using JobPortal.Data;
using JobPortal.Data.Models;
using JobPortal.Services.Data.Interfaces;
using JobPortal.Web.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Data
{
    public class UserService : IUserService
    {

        private readonly JobPortalDbContext dbcontext;
        private readonly IApplicantService applicantService;
        private readonly ICompanyService companyService;

        public UserService(JobPortalDbContext _dbcontext, IApplicantService _applicantService, ICompanyService _companyService)
        {
            this.dbcontext = _dbcontext;
            this.applicantService = _applicantService;
            this.companyService = _companyService;
        }

        public async Task<IEnumerable<UserViewModel>> All(string userId)
        {
            string fullName = await GetFullNameById(userId);

            List<UserViewModel> allUsers = await dbcontext
                .Users
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    
                })
                .ToListAsync();

            foreach (UserViewModel user in allUsers)
            {
                Applicant? applicant = dbcontext.Applicants
                    .FirstOrDefault(a => a.ApplicationUserId.ToString() == user.Id);
                Company? company = dbcontext.Companies
                  .FirstOrDefault(c => c.ApplicationUserId.ToString() == user.Id);

                if (applicant != null)
                {
                    user.PhoneNumber = applicant.Phone;
                    user.FullName = await GetFullNameById(user.Id.ToString());
                }

                if (company != null)
                {
                    user.PhoneNumber = company.Phone;
                    user.FullName = await GetFullNameById(user.Id.ToString());


                }


            }

            return allUsers;
        }

        

        public async Task<string> GetFullNameById(string userId)
        {
            string fullName = "";

            ApplicationUser? user = await dbcontext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            if (user == null)
            {
                return string.Empty;
            }

            bool IsApplicant = await applicantService.ApplicantExistsByUserId(userId);
            bool IsCompany = await companyService.CompanyExistsByUserId(userId);

            if (IsApplicant)
            {
                var applicant = await applicantService.GetApplicantByApplicationUserId(userId);

                fullName = $"{applicant.FirstName} {applicant.LastName}";
                
            }

            if (IsCompany)
            {
                var company = await companyService.GetCompanyByApplicationUserId(userId);

                fullName = $"{company.Name}";

            }

            return fullName;

        }
    }
}
