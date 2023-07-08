using JobPortal.Web.ViewModels.JobOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JopPortal.Services.Data.Models.JobOffer
{
    public class AllJobOffersFilteredAndPagedServiceModel
    {

        public int TotalJobOffersCount { get; set; }
        public IEnumerable<JobOfferAllViewModel> JobOffers { get; set; } = new List<JobOfferAllViewModel>();

    }
}
