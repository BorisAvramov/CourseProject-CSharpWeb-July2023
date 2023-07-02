using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data.Models
{
    [Comment("This is mapping table for many to many relation -> one applicant can apply for many job offers and many applicants can apply for one job offer")]
    public class ApplicantJobOffer
    {
        [Required]
        public bool IsDeleted { get; set; }


        [ForeignKey(nameof(Applicant))]
        public Guid ApplicantId { get; set; }
        public virtual Applicant Applicant { get; set; } = null!;



        [ForeignKey(nameof(JobOffer))]
        public Guid JobOfferId { get; set; }
        public virtual JobOffer JobOffer { get; set; } = null!;


    }
}
