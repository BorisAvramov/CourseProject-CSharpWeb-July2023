using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data.Models
{
    [Comment("This is a required programming language for the job - C#, JS, PHP, Python")]
    public class ProgrammingLanguage
    {
        public ProgrammingLanguage()
        {
            this.JobOffers = new HashSet<JobOffer>();
            this.Applicants = new HashSet<Applicant>();
        }


        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;


        [Comment("Job offers with that required programming language -> one to many relation")]
        public virtual ICollection<JobOffer> JobOffers { get; set; }


        [Comment("Applicants that offer that language -> one to many relation")]
        public virtual ICollection<Applicant> Applicants { get; set; }

    }
}
