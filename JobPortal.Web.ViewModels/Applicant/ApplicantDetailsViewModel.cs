using JobPortal.Data.Models;
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
    /// View Model to display Applicant Details
    /// </summary>
    public class ApplicantDetailsViewModel
    {
        public string Id { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;


     
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;



        [Display(Name = "Last Name")]

        public string LastName { get; set; } = null!;


      
        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;


        public int ApplicantJobOffersCount => ApplicantJobOffers.Count();


        public IEnumerable<ApplicantJobOffer> ApplicantJobOffers { get; set; } = new List<ApplicantJobOffer>();

    }
}
