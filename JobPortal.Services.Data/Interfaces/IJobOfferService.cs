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
        Task AddJobOffer(JobOfferAddFormViewModel model, string userId );
        Task <AllJobOffersFilteredAndPagedServiceModel> All(AllJobOffersQueryModel queryModel);
        Task <IEnumerable<JobOfferAllViewModel>> AllByCompanyId(string userId);




    }
}
