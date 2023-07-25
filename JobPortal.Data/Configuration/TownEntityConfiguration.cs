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
    /// Configuring Town entity for   Default Value of IsDeleted Property and Seed database
    /// </summary>
    public class TownEntityConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder
              .Property(t => t.IsDeleted)
              .HasDefaultValue(false);

            builder.HasData(this.GenerateTowns());
        }


        private Town[] GenerateTowns()
        {
            ICollection<Town> towns = new HashSet<Town>();

            Town town;

            town = new Town()
            {
                Id = 1,
                Name = "Sofia",
            };

            towns.Add(town);

            town = new Town()
            {
                Id = 2,
                Name = "Varna",
            };

            towns.Add(town); 
            
            town = new Town()
            {
                Id = 3,
                Name = "Burgas",
            };

            towns.Add(town); 
            
            town = new Town()
            {
                Id = 4,
                Name = "Plovdiv",
            };

            towns.Add(town); 
            
            town = new Town()
            {
                Id = 5,
                Name = "Ruse",
            };

            towns.Add(town); 
            
            town = new Town()
            {
                Id = 6,
                Name = "Stara Zagora",
            };

            towns.Add(town);

            return towns.ToArray();

        }
    }
}
