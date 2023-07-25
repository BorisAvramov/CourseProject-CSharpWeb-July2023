using JobPortal.Data.Models;
using JobPortal.Web.ViewModels.JobOffer.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Web.ViewModels.JobOffer
{
    /// <summary>
    /// View Model with properties to filter, sorting and pagination!
    /// </summary>

    public class AllJobOffersQueryModel
    {
        public AllJobOffersQueryModel()
        {
            this.CurrentPage = 1;
            this.JobOffersPerPage = 3;
        }



        [Display(Name ="Job Type")]
        public string? JobType { get; set; }

        public string? Level { get; set; }

        public string? Town { get; set; }

        [Display(Name = "Programming Language")]
        public string? ProgrammingLanguage { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }


        [Display(Name = "Sort Job Offers By")]
       public JobOfferSorting JobOfferSorting { get; set; }


        public int CurrentPage { get; set; }

        public int JobOffersPerPage { get; set; }

        public int TotalJobOffers { get; set; }

        //public int countOfApplicants => JobOfferApplicants.Count();




        //public IEnumerable<ApplicantJobOffer> JobOfferApplicants { get; set; } = new List<ApplicantJobOffer>();


        public IEnumerable<Town> Towns { get; set; } = new List<Town>();



        public IEnumerable<ProgrammingLanguage> ProgrammingLanguages { get; set; } = new List<ProgrammingLanguage>();


   
        public IEnumerable<Level> Levels { get; set; } = new List<Level>();


     
        public IEnumerable<JobType> JobTypes { get; set; } = new List<JobType>();



        public IEnumerable<JobOfferAllViewModel> JobOffers { get; set; } = new List<JobOfferAllViewModel>();



    }
}
