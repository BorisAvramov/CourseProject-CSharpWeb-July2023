namespace JobPortal.Common
{
    /// <summary>
    /// Validations constants  for Properties of Entities!
    /// </summary>
    public static class EntityValidationConstants
    {
        public static class Company
        {
            public const int NameMaxLength = 100;
            public const int NameMinLength = 4;

            public const int ImageUrlMaxLength = 2048;

            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;

            public const int AddressMaxLength = 100;
            public const int AddressMinLength = 4;

            public const int DescriptionMinLength = 5;
        }

        public static class Town
        {
            public const int NameMaxLength = 20;
            public const int NameMinLength = 3;

        }

        public static class JobOffer
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;

            public const int LevelMaxLength = 10;
            public const int LevelMinLength = 3;

        }

        public static class Applicant
        {
            public const int FirstNameMaxLength = 15;
            public const int FirstNameMinLength = 2;

            public const int LastNameMaxLength = 15;
            public const int LastNameMinLength = 2;

        }
        public static class JobType
        {
            public const int TypeNameMaxLength = 6;
            public const int TypeNameMinLength = 6;

           

        }

    }
}