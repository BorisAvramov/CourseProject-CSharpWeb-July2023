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
    public class ProgrammingLanguageEntityConfiguration : IEntityTypeConfiguration<ProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            builder
               .Property(pl => pl.IsDeleted)
               .HasDefaultValue(false);


        }
    }
}
