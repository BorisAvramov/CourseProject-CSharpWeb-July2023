using JobPortal.Data.Models;
using JobPortal.Web.ViewModels.JobOffer;
using JobPortal.Web.ViewModels.JobOffer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JobPortal.Web.ViewModels.Applicant
{

    /// <summary>
    /// View Model with properties to filter, sorting and pagination!
    /// </summary>

    public class AllApplicantsQueryModel
    {
        public AllApplicantsQueryModel()
        {
            this.CurrentPage = 1;
            this.ApplicantsPerPage = 3;
        }




        public string? Level { get; set; }

        public string? Town { get; set; }

        [Display(Name = "Programming Language")]
        public string? ProgrammingLanguage { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }



        public int CurrentPage { get; set; }

        public int ApplicantsPerPage { get; set; }

        public int TotalApplicants { get; set; }


        public IEnumerable<Town> Towns { get; set; } = new List<Town>();



        public IEnumerable<ProgrammingLanguage> ProgrammingLanguages { get; set; } = new List<ProgrammingLanguage>();



        public IEnumerable<Level> Levels { get; set; } = new List<Level>();





        public IEnumerable<ApplicantAllViewModel> Applicants { get; set; } = new List<ApplicantAllViewModel>();


    }
}
