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
    public class CompanyEntityConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder
                .Property(c => c.IsDeleted)
                .HasDefaultValue(false);

            builder.HasData(this.GenerateCompanies());

        }

        private Company[] GenerateCompanies()
        {

            ICollection<Company> companies = new HashSet<Company>();

            Company company = new Company()
            {
                Id = Guid.Parse("9AC7482A-10CE-4D60-9D3B-4CCF2724887B"),
                Name = "Software University",
                ImageUrl = "~/img/topEmlpoyers/SoftUni.png",
                Phone = "+359111111111",
                Address = "78 Alexander Malinov Blvd., fl. 1",
                Description = "Software University Ltd. is a private educational institution for practical training of programmers and IT specialists.",
                ApplicationUserId = Guid.Parse("90489BF2-B2D3-40D9-893A-BD907ED03A98"), // AspNetUser Id
                
                

            };
            companies.Add(company);

            return companies.ToArray();
        }

    }
}
