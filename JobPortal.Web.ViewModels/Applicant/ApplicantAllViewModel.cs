using JobPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static JobPortal.Common.EntityValidationConstants.Applicant;

namespace JobPortal.Web.ViewModels.Applicant
{
    public class ApplicantAllViewModel
    {
        public string Id { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

      
        [Display(Name ="First Name")]
        public string FirstName { get; set; } = null!;


     
  
        [Display(Name = "Last Name")]

        public string LastName { get; set; } = null!;

        
        public string Town  { get; set; }  =null!;

     
        public string Level { get; set; } = null!;

        
        [Display(Name ="Programming Language")]
        public string ProgrammingLanguage { get; set; } = null!;

       
       


    }
}
