using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static JobPortal.Common.EntityValidationConstants.Company;

namespace JobPortal.Web.ViewModels.Company
{
    public class BecomeRecruiterFormModel
    {
        [Required]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        [Display(Name ="Company Name")]
        public string Name { get; set; } = null!;


        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Display(Name ="Image Url")]
        public string ImageUrl { get; set; } = null!;


        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        [MinLength(PhoneNumberMinLength)]
        [Phone]
        [Display(Name ="Phone Number")]
        public string Phone { get; set; } = null!;


        [Required]
        [MaxLength(AddressMaxLength)]
        [MinLength(AddressMinLength)]

        public string Address { get; set; } = null!;


        [Required]
        [Display(Name ="About Company")]
        public string Description { get; set; } = null!;


    }
}
