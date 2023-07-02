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
    public class ApplicantEntityConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder
               .Property(a => a.IsDeleted)
               .HasDefaultValue(false);

            builder
               .HasOne(a => a.Level)
               .WithMany(l => l.Applicants)
               .HasForeignKey(a => a.LevelId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasOne(a => a.Town)
              .WithMany(t => t.Applicants)
              .HasForeignKey(a => a.TownId)
              .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasOne(a => a.ProgrammingLanguage)
              .WithMany(pl => pl.Applicants)
              .HasForeignKey(a => a.TownId)
              .OnDelete(DeleteBehavior.Restrict);

            

        }
    }
}
