using JobPortal.Data.Models;
using JobPortal.Web.ViewModels.Applicant;
using JobPortal.Web.ViewModels.Company;
using JobPortal.Web.ViewModels.JobOffer;
using JopPortal.Services.Data.Models.Applicant;
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

        Task<AllApplicantsFilteredAndPagedServiceModel> All(AllApplicantsQueryModel queryModel);

        Task<Applicant> GetApplicantById(string applicantId);

        Task<ApplicantDetailsViewModel> GetDetailsOfApplicant(Applicant applicant, string applicantId);

        Task<Applicant> GetApplicantByApplicationUserId(string applicationUserId);

        Task<bool> IsApplicantAppliedForTheJob(Guid applicantId, Guid jobOfferId);


        Task ApplicantApplyForOffer(Guid applicantId, Guid jobOfferId);







    }
}
