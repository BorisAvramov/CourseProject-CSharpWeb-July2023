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
    public class LevelEntityConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder
               .Property(l => l.IsDeleted)
               .HasDefaultValue(false);
            builder.HasData(this.GenerateLevels());
        }

        private Level[] GenerateLevels()
        {
            ICollection<Level> levels = new HashSet<Level>();

            Level level;

            level = new Level()
            {
                Id = 1,
                Name = "Junior",
            };

            levels.Add(level);

            level = new Level()
            {
                Id = 2,
                Name = "Mid",
            };

            levels.Add(level);

            level = new Level()
            {
                Id = 3,
                Name = "Senior",
            };

            levels.Add(level); 

            return levels.ToArray();

        }

    }
}
