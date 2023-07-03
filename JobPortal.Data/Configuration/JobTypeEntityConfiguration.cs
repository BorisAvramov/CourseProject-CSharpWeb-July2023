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

            builder.HasData(this.GenerateJobTypes());
        }

        private JobType[] GenerateJobTypes()
        {
            ICollection<JobType> jobTypes = new HashSet<JobType>();

            JobType jobType;

            jobType = new JobType()
            {
                Id = 1,
                TypeName = "Office",
            };
            jobTypes.Add(jobType);


            jobType = new JobType()
            {
                Id = 2,
                TypeName = "Remote",
            };
            jobTypes.Add(jobType); 


            jobType = new JobType()
            {
                Id = 3,
                TypeName = "Hybrid",
            };
            jobTypes.Add(jobType); 


            return jobTypes.ToArray();

        }
    }
}
