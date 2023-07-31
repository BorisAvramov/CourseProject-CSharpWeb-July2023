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
        /// <summary>
        /// Check if user is Applicant!
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true or false</returns>
        Task<bool> ApplicantExistsByUserId(string userId);


        
        /// <summary>
        /// Check if there is an Applicant with this phone number!
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>true or false</returns>
        Task<bool> ApplicantExistsByPhoneNumber(string phoneNumber);


        /// <summary>
        /// Add Applicant entity. User becomes Appliant
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task Create(BecomeApplicantFormModel model, string userId);


        /// <summary>
        /// Get All Applicants filtered and paged
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns>AllApplicantsFilteredAndPagedServiceModel</returns>
        Task<AllApplicantsFilteredAndPagedServiceModel> All(AllApplicantsQueryModel queryModel);


        /// <summary>
        /// Get Applicant entity by Id!
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns>Applicant</returns>
        Task<Applicant> GetApplicantById(string applicantId);

        /// <summary>
        /// Get Details of Applicant by Id
        /// </summary>
        /// <param name="applicant"></param>
        /// <param name="applicantId"></param>
        /// <returns>Applicant Details</returns>
        Task<ApplicantDetailsViewModel> GetDetailsOfApplicant(Applicant applicant, string applicantId);

        /// <summary>
        /// Get Applicant entity by applicationUserId / userID!
        /// </summary>
        /// <param name="applicationUserId"></param>
        /// <returns>Applicant</returns>
        Task<Applicant> GetApplicantByApplicationUserId(string applicationUserId);


        /// <summary>
        /// Check if Applicant is applied for a job
        /// </summary>
        /// <param name="applicantId"></param>
        /// <param name="jobOfferId"></param>
        /// <returns>true or false</returns>
        Task<bool> IsApplicantAppliedForTheJob(Guid applicantId, Guid jobOfferId);


        /// <summary>
        /// When Applicant apply for a Job, Add to ApplicantsJobOffers many to many table.
        /// Add applicantId and jobOfferId to mapping table
        /// </summary>
        /// <param name="applicantId"></param>
        /// <param name="jobOfferId"></param>
        /// <returns></returns>
        Task ApplicantApplyForOffer(Guid applicantId, Guid jobOfferId);


        /// <summary>
        /// Get all Applicants Applied for Job Offer!
        /// </summary>
        /// <param name="jobOfferId"></param>
        /// <returns></returns>
        Task<IEnumerable<ApplicantAllViewModel>> AllByJobOfferId(string jobOfferId);







    }
}
