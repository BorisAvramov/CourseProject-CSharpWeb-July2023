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
    /// Configuring Applicant entity for Relations, Delete Behaviour, Default Value of IsDeleted Property and Seed database
    /// </summary>
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
              .HasForeignKey(a => a.ProgrammingLanguageId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateApplicants());

        }

        private Applicant[] GenerateApplicants()
        {

            ICollection<Applicant> applicants = new HashSet<Applicant>();

            Applicant applicant = new Applicant()
            {
                Id = Guid.Parse("4E2A1953-BAB0-4614-9279-F89C50448ED8"),
                FirstName = "Boris",
                LastName = "Avramov",
                Phone = "+359666666666",
                ImgUrl = "~/img/applicants/b.a.jpg",
                TownId = 2,
                ProgrammingLanguageId = 1,
                LevelId = 1,
                ApplicationUserId = Guid.Parse("0ED38564-3050-4A21-AF48-D17CD6CD4C60")
                


            };
            applicants.Add(applicant);

            return applicants.ToArray();
        }
    }
}
