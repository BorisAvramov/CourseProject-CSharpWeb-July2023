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
    public class JobOfferEntityConfiguration : IEntityTypeConfiguration<JobOffer>
    {
        public void Configure(EntityTypeBuilder<JobOffer> builder)
        {
            builder
                .Property(h => h.IsDeleted)
                .HasDefaultValue(false);

            builder
                .Property(h => h.CreatedOn)
                .HasDefaultValue(DateTime.UtcNow);

            builder
               .HasOne(jo => jo.Company)
               .WithMany(c => c.JobOffers)
               .HasForeignKey(h => h.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(jo => jo.Level)
               .WithMany(l => l.JobOffers)
               .HasForeignKey(h => h.LevelId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(jo => jo.Town)
               .WithMany(t => t.JobOffers)
               .HasForeignKey(h => h.TownId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(jo => jo.JobType)
               .WithMany(jt => jt.JobOffers)
               .HasForeignKey(h => h.JobTypeId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(jo => jo.ProgrammingLanguage)
               .WithMany(pl => pl.JobOffers)
               .HasForeignKey(h => h.ProgrammingLanguageId)
               .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
