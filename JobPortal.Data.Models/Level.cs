using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data.Models
{
    [Comment("This is a required lever for the job - junior, mid or senior")]
    public class Level
    {
        public Level()
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

        [Comment("Job offers from that required level -> one to many relation")]
        public virtual ICollection<JobOffer> JobOffers { get; set; }


        [Comment("Applicants that offer that level")]
        public virtual ICollection<Applicant> Applicants { get; set; }
    }
}
