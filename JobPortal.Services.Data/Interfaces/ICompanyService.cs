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
        /// <summary>
        /// Check if user is Company by Id!
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true or false</returns>
        Task<bool> CompanyExistsByUserId(string userId);

        /// <summary>
        /// Check if there is a Company with this phone number!
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true or false</returns>
        Task<bool> CompanyExistsByPhoneNumber(string phoneNumber);


        /// <summary>
        /// Add Company entity. User becomes Company
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task Create(BecomeRecruiterFormModel model, string userId);


        /// <summary>
        /// Get Company by Id of Application User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Company entity</returns>
        Task <Company> GetCompanyByApplicationUserId( string userId);

    }
}
