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
    public class CompanyTownEntityConfiguration : IEntityTypeConfiguration<CompanyTown>
    {
        public void Configure(EntityTypeBuilder<CompanyTown> builder)
        {
            builder
               .Property(ct => ct.IsDeleted)
               .HasDefaultValue(false);

            builder
                .HasKey(x => new { x.CompanyId, x.TownId });

            builder
              .HasOne(ct => ct.Company)
              .WithMany(c => c.CompanyTowns)
              .HasForeignKey(ct => ct.CompanyId)
              .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasOne(ct => ct.Town)
              .WithMany(t => t.TownCompanies)
              .HasForeignKey(ct => ct.TownId)
              .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
