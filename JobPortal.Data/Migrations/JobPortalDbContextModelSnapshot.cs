﻿// <auto-generated />
using System;
using JobPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobPortal.Data.Migrations
{
    [DbContext(typeof(JobPortalDbContext))]
    partial class JobPortalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JobPortal.Data.Models.Applicant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("This is a company reference to application user");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LevelId")
                        .HasColumnType("int")
                        .HasComment("Junior, Intermediate, Senior level that the applicant considers to have");

                    b.Property<int>("ProgrammingLanguageId")
                        .HasColumnType("int")
                        .HasComment("software language that the applicant has a good command of");

                    b.Property<int>("TownId")
                        .HasColumnType("int")
                        .HasComment("Town of the applicant where he is searching a job");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("LevelId");

                    b.HasIndex("ProgrammingLanguageId");

                    b.HasIndex("TownId");

                    b.ToTable("Applicants");

                    b.HasComment("This is an applicant profile for a job which is application user");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4e2a1953-bab0-4614-9279-f89c50448ed8"),
                            ApplicationUserId = new Guid("0ed38564-3050-4a21-af48-d17cd6cd4c60"),
                            FirstName = "Boris",
                            ImgUrl = "~/img/applicants/b.a.jpg",
                            IsDeleted = false,
                            LastName = "Avramov",
                            LevelId = 1,
                            ProgrammingLanguageId = 1,
                            TownId = 2
                        });
                });

            modelBuilder.Entity("JobPortal.Data.Models.ApplicantJobOffer", b =>
                {
                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JobOfferId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("ApplicantId", "JobOfferId");

                    b.HasIndex("JobOfferId");

                    b.ToTable("ApplicantsJobOffers");

                    b.HasComment("This is mapping table for many to many relation -> one applicant can apply for many job offers and many applicants can apply for one job offer");
                });

            modelBuilder.Entity("JobPortal.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasComment("This is identity user for the app");
                });

            modelBuilder.Entity("JobPortal.Data.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("This is a company reference to application user");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Companies");

                    b.HasComment("This is a Company profile which is searching a talent and the company is ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9ac7482a-10ce-4d60-9d3b-4ccf2724887b"),
                            Address = "78 Alexander Malinov Blvd., fl. 1",
                            ApplicationUserId = new Guid("90489bf2-b2d3-40d9-893a-bd907ed03a98"),
                            Description = "Software University Ltd. is a private educational institution for practical training of programmers and IT specialists.",
                            ImageUrl = "~/img/topEmlpoyers/SoftUni.png",
                            IsDeleted = false,
                            Name = "Software University",
                            Phone = "+359111111111"
                        });
                });

            modelBuilder.Entity("JobPortal.Data.Models.CompanyTown", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TownId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("CompanyId", "TownId");

                    b.HasIndex("TownId");

                    b.ToTable("CompaniesTowns");

                    b.HasComment("mapping table for many to many relation -> a company could have offices in many towns and many companies could have an office in a town");
                });

            modelBuilder.Entity("JobPortal.Data.Models.JobOffer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("This is the company that published job offer");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 7, 3, 9, 49, 19, 429, DateTimeKind.Utc).AddTicks(5256))
                        .HasComment("This is publish date of job offer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("JobTypeId")
                        .HasColumnType("int")
                        .HasComment("This is a required type of employement - office, remote or hybrid");

                    b.Property<int>("LevelId")
                        .HasColumnType("int")
                        .HasComment("This is a required lever for the job - junior, mid or senior");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("This is position name");

                    b.Property<int>("ProgrammingLanguageId")
                        .HasColumnType("int")
                        .HasComment("This is what programmig language is required for the position");

                    b.Property<int>("TownId")
                        .HasColumnType("int")
                        .HasComment("This is for which town is job offer");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("JobTypeId");

                    b.HasIndex("LevelId");

                    b.HasIndex("ProgrammingLanguageId");

                    b.HasIndex("TownId");

                    b.ToTable("JobOffers");

                    b.HasComment("This is Job Offer published from a company");
                });

            modelBuilder.Entity("JobPortal.Data.Models.JobType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("Id");

                    b.ToTable("JobTypes");

                    b.HasComment("This is a required type of employement - office, remote or hybrid");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            TypeName = "Office"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            TypeName = "Remote"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            TypeName = "Hybrid"
                        });
                });

            modelBuilder.Entity("JobPortal.Data.Models.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Levels");

                    b.HasComment("This is a required lever for the job - junior, mid or senior");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Junior"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Mid"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Senior"
                        });
                });

            modelBuilder.Entity("JobPortal.Data.Models.ProgrammingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProgrammingLanguages");

                    b.HasComment("This is a required programming language for the job - C#, JS, PHP, Python");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "~/img/programmingLanguages/icons8-c-48.png",
                            IsDeleted = false,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "~/img/programmingLanguages/icons8-js-48.png",
                            IsDeleted = false,
                            Name = "JS"
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "~/img/programmingLanguages/icons8-python-48.png",
                            IsDeleted = false,
                            Name = "Python"
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "~/img/programmingLanguages/icons8-php-40.png",
                            IsDeleted = false,
                            Name = "PHP"
                        });
                });

            modelBuilder.Entity("JobPortal.Data.Models.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Towns");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Sofia"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Varna"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Burgas"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Plovdiv"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Ruse"
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Name = "Stara Zagora"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("JobPortal.Data.Models.Applicant", b =>
                {
                    b.HasOne("JobPortal.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Data.Models.Level", "Level")
                        .WithMany("Applicants")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobPortal.Data.Models.ProgrammingLanguage", "ProgrammingLanguage")
                        .WithMany("Applicants")
                        .HasForeignKey("ProgrammingLanguageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobPortal.Data.Models.Town", "Town")
                        .WithMany("Applicants")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Level");

                    b.Navigation("ProgrammingLanguage");

                    b.Navigation("Town");
                });

            modelBuilder.Entity("JobPortal.Data.Models.ApplicantJobOffer", b =>
                {
                    b.HasOne("JobPortal.Data.Models.Applicant", "Applicant")
                        .WithMany("ApplicantJobOffers")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobPortal.Data.Models.JobOffer", "JobOffer")
                        .WithMany("JobOfferApplicants")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("JobOffer");
                });

            modelBuilder.Entity("JobPortal.Data.Models.Company", b =>
                {
                    b.HasOne("JobPortal.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("JobPortal.Data.Models.CompanyTown", b =>
                {
                    b.HasOne("JobPortal.Data.Models.Company", "Company")
                        .WithMany("CompanyTowns")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobPortal.Data.Models.Town", "Town")
                        .WithMany("TownCompanies")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Town");
                });

            modelBuilder.Entity("JobPortal.Data.Models.JobOffer", b =>
                {
                    b.HasOne("JobPortal.Data.Models.Company", "Company")
                        .WithMany("JobOffers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobPortal.Data.Models.JobType", "JobType")
                        .WithMany("JobOffers")
                        .HasForeignKey("JobTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobPortal.Data.Models.Level", "Level")
                        .WithMany("JobOffers")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobPortal.Data.Models.ProgrammingLanguage", "ProgrammingLanguage")
                        .WithMany("JobOffers")
                        .HasForeignKey("ProgrammingLanguageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobPortal.Data.Models.Town", "Town")
                        .WithMany("JobOffers")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("JobType");

                    b.Navigation("Level");

                    b.Navigation("ProgrammingLanguage");

                    b.Navigation("Town");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("JobPortal.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("JobPortal.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("JobPortal.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobPortal.Data.Models.Applicant", b =>
                {
                    b.Navigation("ApplicantJobOffers");
                });

            modelBuilder.Entity("JobPortal.Data.Models.Company", b =>
                {
                    b.Navigation("CompanyTowns");

                    b.Navigation("JobOffers");
                });

            modelBuilder.Entity("JobPortal.Data.Models.JobOffer", b =>
                {
                    b.Navigation("JobOfferApplicants");
                });

            modelBuilder.Entity("JobPortal.Data.Models.JobType", b =>
                {
                    b.Navigation("JobOffers");
                });

            modelBuilder.Entity("JobPortal.Data.Models.Level", b =>
                {
                    b.Navigation("Applicants");

                    b.Navigation("JobOffers");
                });

            modelBuilder.Entity("JobPortal.Data.Models.ProgrammingLanguage", b =>
                {
                    b.Navigation("Applicants");

                    b.Navigation("JobOffers");
                });

            modelBuilder.Entity("JobPortal.Data.Models.Town", b =>
                {
                    b.Navigation("Applicants");

                    b.Navigation("JobOffers");

                    b.Navigation("TownCompanies");
                });
#pragma warning restore 612, 618
        }
    }
}
