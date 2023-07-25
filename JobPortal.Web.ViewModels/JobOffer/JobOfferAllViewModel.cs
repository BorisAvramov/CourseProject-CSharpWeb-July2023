using JobPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Web.ViewModels.JobOffer
{

    /// <summary>
    /// View Model to display Job Offer object
    /// </summary>
    public class JobOfferAllViewModel
    {

        public string Id { get; set; } = null!;
        [Display(Name ="Title")]
        public string Name { get; set; } = null!;
        [Display(Name ="Published on")]
        public string CreatedOn { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Display(Name = "Programming Language")]
        public string ProgrammingLanguage { get; set; } = null!;

        
        public  string Town { get; set; } = null!;

        public string  Level { get; set; } = null!;

        [Display(Name = "Job Type")]
        public string JobType { get; set; } = null!;

        [Display(Name = "Company Name")]
        public string  Company { get; set; } = null!;


        public string CompanyImageUrl { get; set; } = null!;

        [Display(Name = "Count of Applicants")]
        public int JobOfferApplicantsCount { get; set; }


        
    }
}
