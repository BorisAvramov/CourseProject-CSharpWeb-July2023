using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static JobPortal.Common.EntityValidationConstants.JobOffer;

namespace JobPortal.Data.Models
{
    [Comment("This is Job Offer published from a company")]
    public class JobOffer
    {
        public JobOffer()
        {
            this.Id = Guid.NewGuid();
            this.JobOfferApplicants = new HashSet<ApplicantJobOffer>();
        }



        [Key]
        public Guid Id { get; set; }


        [Required]
        public bool IsDeleted { get; set; }


        [Comment("This is position name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;


        [Comment("This is publish date of job offer")]
        [Required]
        public DateTime CreatedOn { get; set; }


        [Required]
        public string Description { get; set; } = null!;


        [Comment("This is what programmig language is required for the position")]
        [ForeignKey(nameof(ProgrammingLanguage))]
        public int ProgrammingLanguageId { get; set; }
        public virtual ProgrammingLanguage ProgrammingLanguage { get; set; } = null!;



        [Comment("This is for which town is job offer")]
        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }

        public virtual Town Town { get; set; } = null!;



        [Comment("This is a required lever for the job - junior, mid or senior")]
        [ForeignKey(nameof(Level))]
        public int LevelId { get; set; }
        public virtual Level Level { get; set; } = null!;


        [Comment("This is a required type of employement - office, remote or hybrid")]
        [ForeignKey(nameof(JobType))]
        public int JobTypeId { get; set; }

        public virtual JobType JobType { get; set; } = null!;


        [Comment("This is the company that published job offer")]
        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;


        [Comment("This is collection of all applicants for the position -> many to many relation")]
        public virtual ICollection<ApplicantJobOffer> JobOfferApplicants { get; set; }


    }
}
