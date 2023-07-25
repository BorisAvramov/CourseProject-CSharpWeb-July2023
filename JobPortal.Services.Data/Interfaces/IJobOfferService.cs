using JobPortal.Data.Models;
using JobPortal.Web.ViewModels.JobOffer;
using JopPortal.Services.Data.Models.JobOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Data.Interfaces
{
    public interface IJobOfferService
    {
        /// <summary>
        /// Company creates Job Offer.
        /// Add Job Offer to CompanyJobOffers
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task AddJobOffer(JobOfferAddFormViewModel model, string userId );

        /// <summary>
        /// Get All Job Offers filtered and paged
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns>AllJobOffersFilteredAndPagedServiceModel</returns>
        Task<AllJobOffersFilteredAndPagedServiceModel> All(AllJobOffersQueryModel queryModel);

        /// <summary>
        /// Get all Job Offers Published by Company!
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>IEnumerable<JobOfferAllViewModel></returns>
        Task<IEnumerable<JobOfferAllViewModel>> AllByCompanyId(string userId);

        /// <summary>
        /// Get Details of Job Offer
        /// </summary>
        /// <param name="jobOffer"></param>
        /// <param name="jobOfferId"></param>
        /// <returns>JobOfferDetailsViewModel</returns>
        Task<JobOfferDetailsViewModel> GetDetailsOfJobOffer(JobOffer jobOffer, string jobOfferId);

        /// <summary>
        /// Get Job Offer by Id
        /// </summary>
        /// <param name="jobOfferId"></param>
        /// <returns>JobOffer Entity</returns>
        Task<JobOffer> GetJobOfferById(string jobOfferId);

        /// <summary>
        /// Set IsDelete property of Job Offer to true
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task Delete(string id, string userId);

        /// <summary>
        /// Edit Properties of Job Offer
        /// </summary>
        /// <param name="jobOffer"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task  Edit(JobOffer jobOffer, JobOfferEditFormViewModel model);

        /// <summary>
        /// Get all Job Offers Applied from Applicant!
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>IEnumerable<JobOfferAllViewModel></returns>
        Task<IEnumerable<JobOfferAllViewModel>> AllByApplicantId(string applicantId);




    }
}
