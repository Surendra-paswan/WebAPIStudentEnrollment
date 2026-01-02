namespace StudentRegistrationForm.EnumValues
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public enum Nationality
    {
        Nepal,
        American,
        Canadian,
        British,
        Australian,
        Indian,
        Chinese,
        German,
        French,
        Japanese,
        Mexican,
        Brazilian,
        SouthAfrican,
        Italian,
        Russian,
        Spanish,
        Other
    }

    public enum BloodGroup
    {
        A_Positive,
        A_Negative,
        B_Positive,
        B_Negative,
        AB_Positive,
        AB_Negative,
        O_Positive,
        O_Negative
    }

    public enum MaritalStatus
    {
        Single,
        Married,
        Divorced,
        Widowed
    }

    public enum DisabilityType
    {
        None,
        VisualImpairment,
        HearingImpairment,
        MobilityImpairment,
        CognitiveImpairment,
        Other
    }

    public enum AddressType
    {
        Permanent,
        Temporary
    }

    public enum GardianType
    {
        Father,
        Mother,
        Guardian,
        Other
    }
    public enum AnnualFamilyIncome
    {
        NoIncome = 0,

        Below200000 = 1,

        Between200001And500000 = 2,

        Between500001And1000000 = 3,

        Between1000001And2000000 = 4,

        Above2000000 = 5
    }
    public enum Faculty
    {
        Science,
        Management,
        Humanities,
        Education,
        Engineering,
        Law,
        Medicine,
        Agriculture,
        Arts,
        SocialSciences,
        Other
    }

    public enum AcademicProgram
    {
       BTech,
       BBA,
       BSCCSIT,
       BA,
       Bed,
       LLB,
       DPharm,
       BPharm,
       BScAg,
       MA
    }

    public enum Level
    {
        Diploma,
        Bachelor,
        Master,
        PhD,
        Other
    }

    //public enum AcademicYear
    //{
    //    FirstYear,
    //    SecondYear,
    //    ThirdYear,
    //    FourthYear,
    //    Other
    //}
    public enum AcademicYear
    {
        Year2078 = 2078,
        Year2079 = 2079,
        Year2080 = 2080,
        Year2081 = 2081,
        Year2082 = 2082,
        Year2083 = 2083,
        Year2084 = 2084,
        Year2085 = 2085
    }

    public enum Semester
    {
        FirstSemester,
        SecondSemester,
        ThirdSemester,
        FourthSemester,
        FifthSemester,
        SixthSemester,
        SeventhSemester,
        EighthSemester,
        Other
    }

    public enum Section
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P
    }

    public enum AcademicStatus
    {
        Active,
        OnHold,
        Completed,
        DroppedOut
    }

    public enum Qualification
    {
        SEE,
        SLC,
        PlusTwo,
        Bachelor,
        Master,
        PhD,
        Other
    }

    public enum FeeCategory
    {
        Regular,
        SelfFinanced,
        Scholarship,
        Quota
    }

    public enum ScholarshipType
    {
        Government,
        Private,
        Institutional,
        Other
    }

    public enum BankName
    {
        NabilBank,
        EverestBank,
        HimalayanBank,
        StandardChartered,
        NICAsia,
        SiddharthaBank,
        Other
    }

    public enum DocumentType
    {
        Photo,
        Signature,
        Citizenship,
        CharacterCertificate,
        Other
    }

    public enum TransportationMethod
    {
        Walk,
        Bicycle,
        Bus,
        PrivateVehicle
    }

    public enum ScholarType
    {
        Hosteller,
        DayScholar
    }

    public enum AnnualIncome
    {
        LessThan5Lakh,
        Between5And10Lakh,
        Between10And20Lakh,
        MoreThan20Lakh
    }
}
