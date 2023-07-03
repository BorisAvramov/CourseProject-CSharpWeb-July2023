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


            builder.HasData(this.GenerateJobOffers());

        }
         private JobOffer[] GenerateJobOffers()
        {

            ICollection<JobOffer> jobOffers = new HashSet<JobOffer>();

            JobOffer jobOffer = new JobOffer()
            {
                Id = Guid.Parse("FEA40DF4-A755-4A4E-8185-34EB17D90EA1"),
                Name = "C# .NET Developer",
                Description = "As a .NET Developer your primary focus will be the development of software components using C# (.NET Core/.NET Standard wirh.The role of a . NET developer is to develop, improve, troubleshoot, and maintain computer software applications. You are expected to plan, design, and develop new feature functionality of a software application, and identify, debug, and troubleshoot defects.",
                ProgrammingLanguageId = 1,
                TownId = 2,
                LevelId = 1,
                JobTypeId = 2,
                CompanyId = Guid.Parse("9AC7482A-10CE-4D60-9D3B-4CCF2724887B") // Company Id




            };
            jobOffers.Add(jobOffer);

            return jobOffers.ToArray();
        }

    }
}
