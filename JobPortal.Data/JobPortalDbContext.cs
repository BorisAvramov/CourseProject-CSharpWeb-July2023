using JobPortal.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace JobPortal.Data
{
    public class JobPortalDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public JobPortalDbContext(DbContextOptions<JobPortalDbContext> options)
            : base(options)
        {


        }

        public DbSet<Applicant> Applicants { get; set; } = null!;
        public DbSet<JobOffer> JobOffers { get; set; } = null!;
        public DbSet<ApplicantJobOffer> ApplicantsJobOffers { get; set; } = null!;
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Town> Towns { get; set; } = null!;
        public DbSet<CompanyTown> CompaniesTowns { get; set; } = null!;
        public DbSet<JobType> JobTypes { get; set; } = null!;
        public DbSet<Level> Levels { get; set; } = null!;
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(JobPortalDbContext))
                                      ?? Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);


            base.OnModelCreating(builder);
        }

    }
}