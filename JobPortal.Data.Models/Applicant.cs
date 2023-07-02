using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data.Models
{
    [Comment("This is an applicant profile for a job which is application user")]
    public class Applicant
    {
        public Applicant()
        {
            this.Id = Guid.NewGuid();
            this.ApplicantJobOffers = new HashSet<ApplicantJobOffer>();
        }


        [Key]
        public Guid Id { get; set; }


        [Required]
        public bool IsDeleted { get; set; } 


        [Required]
        public string FirstName { get; set; } = null!;


        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string ImgUrl { get; set; } = null!;


        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public virtual Town Town { get; set; } = null!;




        [Comment("software language that the applicant has a good command of")]
        [ForeignKey(nameof(ProgrammingLanguage))]
        public int ProgrammingLanguageId { get; set; }
        public virtual ProgrammingLanguage ProgrammingLanguage { get; set; } = null!;



        [Comment("Junior, Intermediate, Senior level that the applicant considers to have")]
        [ForeignKey(nameof(Level))]
        public int LevelId { get; set; }
        public virtual Level Level { get; set; } = null!;




        [Comment("This is a company reference to application user")]
        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;




        [Comment("Job offers for which the applicant has applied -> many to many relation")]
        public virtual ICollection<ApplicantJobOffer> ApplicantJobOffers { get; set; }

    }
}
