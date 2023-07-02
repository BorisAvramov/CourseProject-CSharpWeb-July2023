using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static JobPortal.Common.EntityValidationConstants.Company;

namespace JobPortal.Data.Models
{
    [Comment("This is a Company profile which is searching a talent and the company is ApplicationUser")]
    public class Company
    {

        public Company()
        {
            this.Id = Guid.NewGuid();
            this.CompanyTowns = new HashSet<CompanyTown>();
            this.JobOffers = new HashSet<JobOffer>();
        }


        [Key]
        public Guid Id { get; set; }


        [Required]
        public bool IsDeleted { get; set; }


        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;


        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;


        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string Phone { get; set; } = null!;


        [Required]
        [MaxLength(AddressMaxLength)]
        
        public string Address { get; set; } = null!;


        [Required]
        public string Description { get; set; } = null!;



        [Comment("This is a company reference to application user")]
        public Guid ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;




        [Comment("Job offers that company has published -> one to many relations")]
        public virtual ICollection<JobOffer> JobOffers { get; set; }


        [Comment("Towns where company has offices -> many to many relation")]
        public virtual ICollection<CompanyTown> CompanyTowns { get; set; } = null!;

    }
}
