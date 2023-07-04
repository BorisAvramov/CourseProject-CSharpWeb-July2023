using JobPortal.Data.Models;
using JobPortal.Web.ViewModels.Applicant;
using JobPortal.Web.ViewModels.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Data.Interfaces
{
    public interface IApplicantService
    {
        Task<bool> ApplicantExistsByUserId(string userId);

        
        Task<bool> ApplicantExistsByPhoneNumber(string phoneNumber);

        Task Create(BecomeApplicantFormModel model, string userId);

        Task<IEnumerable<Town>> GetTowns();
        Task<IEnumerable<ProgrammingLanguage>> GetProgrammingLanguages();
        Task<IEnumerable<Level>> GetLevels();

    }
}
