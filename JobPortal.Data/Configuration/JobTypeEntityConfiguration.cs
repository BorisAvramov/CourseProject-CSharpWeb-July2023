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
    public class JobTypeEntityConfiguration : IEntityTypeConfiguration<JobType>
    {
        public void Configure(EntityTypeBuilder<JobType> builder)
        {
            builder
               .Property(jt => jt.IsDeleted)
               .HasDefaultValue(false);


        }
    }
}
