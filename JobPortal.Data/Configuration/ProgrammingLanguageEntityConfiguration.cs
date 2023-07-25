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
    /// Configuring ProgrammingLanguage entity for   Default Value of IsDeleted Property and Seed database
    /// </summary>
    public class ProgrammingLanguageEntityConfiguration : IEntityTypeConfiguration<ProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            builder
               .Property(pl => pl.IsDeleted)
               .HasDefaultValue(false);

            builder.HasData(this.GenerateProgrammingLanguagesProgrammingLanguages());

        }

        private ProgrammingLanguage[] GenerateProgrammingLanguagesProgrammingLanguages()
        {
            ICollection<ProgrammingLanguage> ProgrammingLanguages = new HashSet<ProgrammingLanguage>();

            ProgrammingLanguage ProgrammingLanguage;

            ProgrammingLanguage = new ProgrammingLanguage()
            {
                Id = 1,
                Name = "C#",
                ImageUrl = "~/img/programmingLanguages/icons8-c-48.png",
                

            };

            ProgrammingLanguages.Add(ProgrammingLanguage);

            ProgrammingLanguage = new ProgrammingLanguage()
            {
                Id = 2,
                Name = "JS",
                ImageUrl = "~/img/programmingLanguages/icons8-js-48.png"
            };

            ProgrammingLanguages.Add(ProgrammingLanguage);

            ProgrammingLanguage = new ProgrammingLanguage()
            {
                Id = 3,
                Name = "Python",
                ImageUrl = "~/img/programmingLanguages/icons8-python-48.png"
            };

            ProgrammingLanguages.Add(ProgrammingLanguage); 

            ProgrammingLanguage = new ProgrammingLanguage()
            {
                Id = 4,
                Name = "PHP",
                ImageUrl = "~/img/programmingLanguages/icons8-php-40.png"
            };

            ProgrammingLanguages.Add(ProgrammingLanguage); 
           


            return ProgrammingLanguages.ToArray();

        }
    }
}
