using JobPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static JobPortal.Common.EntityValidationConstants.JobOffer;

namespace JobPortal.Web.ViewModels.JobOffer
{
    /// <summary>
    /// Form View  Model for Add Job Offer from Company!
    /// </summary>
    public class JobOfferAddFormViewModel
    {
        [Required]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        [Display(Name ="Title")]
        public string Name { get; set; } = null!;



        [Required]
        public string Description { get; set; } = null!;


        [Display(Name = "Town")]
        public int TownId { get; set; }

        public IEnumerable<Town> Towns { get; set; } = new List<Town>();


        [Display(Name = "Programming Language")]
        public int ProgrammingLanguageId { get; set; }

        public IEnumerable<ProgrammingLanguage> ProgrammingLanguages { get; set; } = new List<ProgrammingLanguage>();


        [Display(Name = "Level")]
        public int LevelId { get; set; }
        public IEnumerable<Level> Levels { get; set; } = new List<Level>();


        [Display(Name = "Job Type")]
        public int JobTypeId { get; set; }
        public IEnumerable<JobType> JobTypes { get; set; } = new List<JobType>();





    }
}
