using JobPortal.Data;
using JobPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Tests
{
    public static class DatabaseSeeder
    {
        public static ApplicationUser ApplicantUserBoris;
        public static ApplicationUser ApplicantUserPesho;
        public static ApplicationUser ApplicantUserAni;
        public static ApplicationUser FutureapplicantUserMIsho;
        public static ApplicationUser FutureCompanyUserBosch;
        public static ApplicationUser CompanyUserSoftUni;
        public static ApplicationUser CompanyUserBosch;

        public static Applicant applicantPesho;
        public static Applicant applicantBoris;
        public static Applicant applicantAni;

        public static Company companySoftUni;
        public static Company companyBosch;

        public static JobOffer jobOfferCSharp;
        public static JobOffer jobOfferJavaScript;

        public static Level JuniorLevel;
        public static Level MidLevel;
        public static Level Senior;

        public static ProgrammingLanguage CSharp;
        public static ProgrammingLanguage JavaScript;

        public static Town Varna;
        public static Town Sofia;

        public static JobType Remote;
        public static JobType Hybrid;
        public static JobType Office;






        public static void SeedDatabase(JobPortalDbContext dbContext)
        {

            ApplicantUserPesho = new ApplicationUser()
            {

                IsDeleted = false,
                UserName = "peshoTheApplicant@applicants.com",
                NormalizedUserName = "PESHOTHEAPPLICANT@APPLICANTS.COM",
                Email = "peshoTheApplicant@applicants.com",
                NormalizedEmail = "PESHOTHEAPPLICANT@APPLICANTS.COM",
                EmailConfirmed = false,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "4dcfc2b0-169a-4b78-9080-4a0e0c6017f2",
                SecurityStamp = "b1ee321a-5d87-4c2c-9556-97dafd24a70e",
                TwoFactorEnabled = false


            };

            ApplicantUserBoris = new ApplicationUser()
            {

                IsDeleted = false,
                UserName = "bobiTheApplicant@applicants.com",
                NormalizedUserName = "BOBITHEAPPLICANT@APPLICANTS.COM",
                Email = "bobiTheApplicant@applicants.com",
                NormalizedEmail = "BOBITHEAPPLICANT@APPLICANTS.COM",
                EmailConfirmed = false,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "aaee03c4-f6de-4fb8-9725-2a3f3804b457",
                SecurityStamp = "ab70573d-a1d9-4657-8de9-6a31a0579f58",
                TwoFactorEnabled = false


            };

            ApplicantUserAni = new ApplicationUser()
            {

                IsDeleted = false,
                UserName = "aniTheApplicant@applicants.com",
                NormalizedUserName = "ANITHEAPPLICANT@APPLICANTS.COM",
                Email = "aniTheApplicant@applicants.com",
                NormalizedEmail = "ANITHEAPPLICANT@APPLICANTS.COM",
                EmailConfirmed = false,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "959241f7-c957-4168-b3a2-ce281825e303",
                SecurityStamp = "P6BT3CVY3ZYCQJ4IXIMMLJRCGO3VQSXP",
                TwoFactorEnabled = false


            };

            FutureapplicantUserMIsho = new ApplicationUser()
            {

                IsDeleted = false,
                UserName = "mishoFuture@future.com",
                NormalizedUserName = "MISHOFUTURE@FUTURE.COM",
                Email = "mishoFuture@future.com",
                NormalizedEmail = "MISHOFUTURE@FUTURE.COM",
                EmailConfirmed = false,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "a4148bd0-d20a-4633-87f3-3b5fbd805590",
                SecurityStamp = "RFCS77SKGVDDC3QY4OVF6PWAMHIZQEBR",
                TwoFactorEnabled = false


            };
            FutureCompanyUserBosch = new ApplicationUser()
            {

                IsDeleted = false,
                UserName = "boschTheCompany@companies",
                NormalizedUserName = "BOSCHTHECOMPANY@COMPANIES",
                Email = "boschTheCompany@companies",
                NormalizedEmail = "BOSCHTHECOMPANY@COMPANIES",
                EmailConfirmed = false,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "5fe1e55f-d451-40fb-9883-63d330c7550d",
                SecurityStamp = "90d0b1b7-810d-43f4-bd1a-8c01382c81ea",
                TwoFactorEnabled = false


            };

            CompanyUserSoftUni = new ApplicationUser()
            {
                IsDeleted = false,
                UserName = "softUniTheCompany@companies.com",
                NormalizedUserName = "SOFTUNITHECOMPANY@COMPANIES.COM",
                Email = "softUniTheCompany@companies.com",
                NormalizedEmail = "SOFTUNITHECOMPANY@COMPANIES.COM",
                EmailConfirmed = false,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "9ebde4a3-2b7e-41d8-a208-83b03cdbe8ed",
                SecurityStamp = "5e7c159d-92a0-41e6-89da-565c034aebab",
                TwoFactorEnabled = false
            };

            CompanyUserBosch = new ApplicationUser()
            {
                IsDeleted = false,
                UserName = "boschTheCompany@companies",
                NormalizedUserName = "BOSCHTHECOMPANY@COMPANIES",
                Email = "boschTheCompany@companies",
                NormalizedEmail = "BOSCHTHECOMPANY@COMPANIES",
                EmailConfirmed = false,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "9be84a0fb-ec8d-48e6-8bcc-0b6a76f825e3",
                SecurityStamp = "2b8f53b6-0bcd-455a-97cd-5986caeb2cbb",
                TwoFactorEnabled = false
            };

            JuniorLevel = new Level()
            {
                IsDeleted = false,
                Name = "Junior"
            };
            MidLevel = new Level()
            {
                IsDeleted = false,
                Name = "Mid"
            };
            Senior = new Level()
            {
                IsDeleted = false,
                Name = "Senior"
            };

            CSharp = new ProgrammingLanguage()
            {
                IsDeleted = false,
                Name = "CSharp",
                ImageUrl = "~/img/programmingLanguages/icons8-c-48.png",
            };
            JavaScript = new ProgrammingLanguage()
            {
                IsDeleted = false,
                Name = "JavaScript",
                ImageUrl = "~/img/programmingLanguages/icons8-js-48.png",

            };

            Varna = new Town()
            {
                IsDeleted = false,
                Name = "Varna"
            };
            Sofia = new Town()
            {
                IsDeleted = false,
                Name = "Sofia"
            };

            Remote = new JobType()
            {
                IsDeleted = false,
                TypeName = "Remote"
            };
            Hybrid = new JobType()
            {
                IsDeleted = false,
                TypeName = "Hybrid"
            };
            Office = new JobType()
            {
                IsDeleted = false,
                TypeName = "Office"
            };
            applicantPesho = new Applicant()
            {
                IsDeleted = false,
                FirstName = "Petar",
                LastName = "Petrov",
                ImgUrl = "https://img.icons8.com/?size=96&id=18738&format=png",
                Phone = "+359777777777",
                Level = JuniorLevel,
                LevelId = JuniorLevel.Id,
                ProgrammingLanguage = CSharp,
                ProgrammingLanguageId = CSharp.Id,
                Town = Varna,
                TownId = Varna.Id,
                ApplicationUser = ApplicantUserPesho,
                

            };

            applicantBoris = new Applicant()
            {
                IsDeleted = false,
                FirstName = "Boris",
                LastName = "Avramov",
                ImgUrl = "https://img.icons8.com/?size=96&id=9pUkuUjlk0Qa&format=png",
                Phone = "+359666666666",
                Level = MidLevel,
                LevelId = MidLevel.Id,
                ProgrammingLanguage = CSharp,
                ProgrammingLanguageId = CSharp.Id,
                Town = Varna,
                TownId = Varna.Id,
                ApplicationUser = ApplicantUserBoris,
                ApplicationUserId = ApplicantUserBoris.Id


            };

            applicantAni = new Applicant()
            {
                IsDeleted = false,
                FirstName = "Ani",
                LastName = "Ivanova",
                ImgUrl = "https://img.icons8.com/?size=96&id=23258&format=png",
                Phone = "+359888888888",
                Level = JuniorLevel,
                LevelId = JuniorLevel.Id,
                ProgrammingLanguage = JavaScript,
                ProgrammingLanguageId = JavaScript.Id,
                Town = Sofia,
                TownId = Sofia.Id,
                ApplicationUser = ApplicantUserAni,


            };

         

            companySoftUni = new Company()
            {

                IsDeleted = false,
                Name = "Software University",
                ImageUrl = "https://media.licdn.com/dms/image/C4D0BAQEApCWzd7I27g/company-logo_200_200/0/1519952435193?e=2147483647&v=beta&t=Ud6mBW_1C3yYHd43wRK9hgMNi_d98JJttbIh2d6iGdU",
                Phone = "+359111111111",
                Address = "78 Alexander Malinov Blvd., fl. 1, Sofia",
                Description = "Software University Ltd. is a private educational institution for practical training of programmers and IT specialists.",
                ApplicationUser = CompanyUserSoftUni
            };
            companyBosch = new Company()
            {

                IsDeleted = false,
                Name = "Robert Bosch GmbH",
                ImageUrl = "https://cdn-s3.angro.bg/media/magiccart/shopbrand/brand/b/o/bosch.jpg",
                Phone = "++359333333333",
                Address = "51b \"Cherni Vrah\" Blvd FPI Business Center Sofia",
                Description = "The Bosch Group is a leading global supplier of technology and services",
                ApplicationUser = CompanyUserBosch
            };

            jobOfferCSharp = new JobOffer()
            {
                IsDeleted= false,
                Name = "C# .NET Developer",
                Description = "As a .NET Developer your primary focus will be the development of software components using C# (.NET Core/.NET Standard with the role of a . NET developer is to develop, improve, troubleshoot, and maintain computer software applications. You are expected to plan, design, and develop new feature functionality of a software application, and identify, debug, and troubleshoot defects.",
                JobType = Remote,
                JobTypeId = Remote.Id,
                Company = companySoftUni,
                CompanyId = companySoftUni.Id,
                ProgrammingLanguage = CSharp,
                ProgrammingLanguageId = CSharp.Id,
                Level = JuniorLevel,
                LevelId = JuniorLevel.Id,
                Town = Sofia,
                TownId = Sofia.Id,
                
                

             




            };
            jobOfferJavaScript = new JobOffer()
            {
                IsDeleted = false,
                Name = "Front-End Developer with React/Angular",
                Description = "As a Senior Front-End Developer, you can be а part of many impactful projects in the public sector and therefore make a true difference to the world. From developing a web application that enables a revolutionary way to attend a driver license exam to providing a new information system that could rationalize clinical studies, patients’ clinical data and prescriptions monitoring.",
                JobType = Remote,
                JobTypeId = Remote.Id,
                Level = Senior,
                LevelId = Senior.Id,
                ProgrammingLanguage = JavaScript,
                ProgrammingLanguageId = JavaScript.Id,
                Town = Varna,
                TownId = Varna.Id,
                Company = companyBosch,
                CompanyId = companyBosch.Id,


               


            };



            dbContext.Users.Add(ApplicantUserPesho);
            dbContext.Users.Add(ApplicantUserBoris);
            dbContext.Users.Add(CompanyUserSoftUni);
            dbContext.Users.Add(FutureapplicantUserMIsho);

            dbContext.Applicants.Add(applicantPesho);
            dbContext.Applicants.Add(applicantBoris);
            dbContext.Applicants.Add(applicantAni);

            dbContext.Companies.Add(companySoftUni);

            dbContext.JobOffers.Add(jobOfferCSharp);
            dbContext.JobOffers.Add(jobOfferJavaScript);

            dbContext.Levels.Add(Senior);
            dbContext.Levels.Add(MidLevel);
            dbContext.Levels.Add(JuniorLevel);

            dbContext.ProgrammingLanguages.Add(CSharp);
            dbContext.ProgrammingLanguages.Add(JavaScript);

            dbContext.Towns.Add(Varna);
            dbContext.Towns.Add(Sofia);

            dbContext.JobTypes.Add(Remote);
            dbContext.JobTypes.Add(Hybrid);
            dbContext.JobTypes.Add(Office);

            dbContext.ApplicantsJobOffers.Add(new ApplicantJobOffer()
            {
                Applicant = applicantPesho,
                JobOffer = jobOfferCSharp,
            });

            dbContext.SaveChanges();

        }
        


    }
}
