using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static JobPortal.Common.EntityValidationConstants.Town;

namespace JobPortal.Data.Models
{
    public class Town

    {
        public Town()
        {
            this.TownCompanies = new HashSet<CompanyTown>();
            this.JobOffers = new HashSet<JobOffer>();
            this.Applicants = new HashSet<Applicant>();
        }


        [Key]
        public int Id { get; set; }


        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;


        [Comment("Job offers published for that town")]
        public virtual  ICollection<JobOffer>  JobOffers { get; set; }

        [Comment("Companies which have offices in that town -> many to many relation")]
        public virtual ICollection<CompanyTown> TownCompanies { get; set; }

        [Comment("Applicants searching job in that town")]
        public virtual ICollection<Applicant> Applicants { get; set; }

    }
}
