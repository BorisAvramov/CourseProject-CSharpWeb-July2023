using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Data.Models;

namespace JobPortal.Web.ViewModels.Applicant
{

    /// <summary>
    /// View Form Model for the User to Become an Applicant
    /// </summary>
    public class BecomeApplicantFormModel
    {
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; } = null!;


        [Required]
        [Display(Name = "Last Name")]

        public string LastName { get; set; } = null!;


        [Required]
        [Phone]
        [Display(Name = "Phone Number")]

        public string Phone { get; set; } = null!;

        [Required]
        [Display(Name = "Image Url")]

        public string ImgUrl { get; set; } = null!;

        [Display(Name ="Town")]
        public int TownId { get; set; }

        public IEnumerable<Town> Towns { get; set; } = new List<Town>();

        [Display(Name = "Programming Language")]

        public int ProgrammingLanguageId { get; set; }

        public IEnumerable<ProgrammingLanguage> ProgrammingLanguages { get; set; } = new List<ProgrammingLanguage>();

        [Display(Name ="Level")]
        public int LevelId { get; set; }
        public IEnumerable<Level> Levels { get; set; } = new List<Level>();


    }
}
