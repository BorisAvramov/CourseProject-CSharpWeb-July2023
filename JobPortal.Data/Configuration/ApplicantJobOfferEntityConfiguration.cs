using JobPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data.Configuration
{

    /// <summary>
    /// Configuring ApplicantJobOffer entity for Relations, Delete Behaviour, Default Value of IsDeleted Property and Primary Key
    /// </summary>

    public class ApplicantJobOfferEntityConfiguration : IEntityTypeConfiguration<ApplicantJobOffer>
    {
        public void Configure(EntityTypeBuilder<ApplicantJobOffer> builder)
        {
            builder
               .Property(ajo => ajo.IsDeleted)
               .HasDefaultValue(false);

            builder
                .HasKey(x => new { x.ApplicantId, x.JobOfferId });

            builder
              .HasOne(ajo => ajo.Applicant)
              .WithMany(a => a.ApplicantJobOffers)
              .HasForeignKey(ajo => ajo.ApplicantId)
              .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasOne(ajo => ajo.JobOffer)
              .WithMany(jo => jo.JobOfferApplicants)
              .HasForeignKey(ajo => ajo.JobOfferId)
              .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
