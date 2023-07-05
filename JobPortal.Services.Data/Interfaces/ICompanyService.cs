using JobPortal.Data.Models;
using JobPortal.Web.ViewModels.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Data.Interfaces
{
    public interface ICompanyService
    {
        Task<bool> CompanyExistsByUserId(string userId);
        Task<bool> CompanyExistsByPhoneNumber(string phoneNumber);

        Task Create(BecomeRecruiterFormModel model, string userId);
        Task <Company> GetCompanyByApplicationUserId( string userId);

    }
}
