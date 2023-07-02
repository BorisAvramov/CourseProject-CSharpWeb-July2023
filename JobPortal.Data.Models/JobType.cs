using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static JobPortal.Common.EntityValidationConstants.JobType;

namespace JobPortal.Data.Models
{
    [Comment("This is a required type of employement - office, remote or hybrid")]
    public class JobType
    {
        public JobType()
        {
            this.JobOffers = new HashSet<JobOffer>();
        }


        [Key]
        public int Id { get; set; }


        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        [MaxLength(TypeNameMaxLength)]
        public string TypeName { get; set; } = null!;


        [Comment("Job offers from that type -> one to many relation")]
        public virtual ICollection<JobOffer> JobOffers { get; set; }

    }
}
