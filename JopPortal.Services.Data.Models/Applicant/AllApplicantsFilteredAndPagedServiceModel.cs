using JobPortal.Web.ViewModels.Applicant;
using JobPortal.Web.ViewModels.JobOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JopPortal.Services.Data.Models.Applicant
{
    public class AllApplicantsFilteredAndPagedServiceModel
    {
        public int TotalApplicantsCount { get; set; }
        public IEnumerable<ApplicantAllViewModel> Applicants { get; set; } = new List<ApplicantAllViewModel>();


    }
}
