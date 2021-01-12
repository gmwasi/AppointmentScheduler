using System;
using AppointmentScheduler.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.Persistence.Seed
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lookup>().HasData(
                new Lookup { Id = 1, Name = "Male", LookupType = LookupType.Gender, UpdatedAt = DateTime.Now },
                new Lookup { Id = 2, Name = "Female", LookupType = LookupType.Gender, UpdatedAt = DateTime.Now },
                new Lookup { Id = 3, Name = "Single", LookupType = LookupType.MaritalStatus, UpdatedAt = DateTime.Now },
                new Lookup { Id = 4, Name = "Married", LookupType = LookupType.MaritalStatus, UpdatedAt = DateTime.Now },
                new Lookup { Id = 5, Name = "Divorced", LookupType = LookupType.MaritalStatus, UpdatedAt = DateTime.Now },
                new Lookup { Id = 6, Name = "Widow", LookupType = LookupType.MaritalStatus, UpdatedAt = DateTime.Now },
                new Lookup { Id = 7, Name = "Widower", LookupType = LookupType.MaritalStatus, UpdatedAt = DateTime.Now },
                new Lookup { Id = 8, Name = "Administrator", LookupType = LookupType.Role, UpdatedAt = DateTime.Now },
                new Lookup { Id = 9, Name = "User", LookupType = LookupType.Role, UpdatedAt = DateTime.Now },
                new Lookup { Id = 10, Name = "CareGiver", LookupType = LookupType.Role, UpdatedAt = DateTime.Now },
                new Lookup { Id = 11, Name = "Parent", LookupType = LookupType.Relationship, UpdatedAt = DateTime.Now },
                new Lookup { Id = 12, Name = "GrandParent", LookupType = LookupType.Relationship, UpdatedAt = DateTime.Now },
                new Lookup { Id = 13, Name = "Spouse", LookupType = LookupType.Relationship, UpdatedAt = DateTime.Now },
                new Lookup { Id = 14, Name = "Sibling", LookupType = LookupType.Relationship, UpdatedAt = DateTime.Now },
                new Lookup { Id = 15, Name = "Child", LookupType = LookupType.Relationship, UpdatedAt = DateTime.Now },
                new Lookup { Id = 16, Name = "Aunt", LookupType = LookupType.Relationship, UpdatedAt = DateTime.Now },
                new Lookup { Id = 17, Name = "Uncle", LookupType = LookupType.Relationship, UpdatedAt = DateTime.Now },
                new Lookup { Id = 18, Name = "Cousin", LookupType = LookupType.Relationship, UpdatedAt = DateTime.Now },
                new Lookup { Id = 19, Name = "In-law", LookupType = LookupType.Relationship, UpdatedAt = DateTime.Now },
                new Lookup { Id = 20, Name = "CHV", LookupType = LookupType.Relationship, UpdatedAt = DateTime.Now },
                new Lookup { Id = 24, Name = "Nairobi", LookupType = LookupType.County, UpdatedAt = DateTime.Now },
                new Lookup { Id = 25, Name = "Kilifi", LookupType = LookupType.County, UpdatedAt = DateTime.Now },
                new Lookup { Id = 26, Name = "Nyamira", LookupType = LookupType.County, UpdatedAt = DateTime.Now },
                new Lookup { Id = 27, Name = "Nakuru", LookupType = LookupType.County, UpdatedAt = DateTime.Now },
                new Lookup { Id = 28, Name = "National", LookupType = LookupType.FacilityLevel, UpdatedAt = DateTime.Now },
                new Lookup { Id = 29, Name = "County", LookupType = LookupType.FacilityLevel, UpdatedAt = DateTime.Now },
                new Lookup { Id = 30, Name = "Sub-County", LookupType = LookupType.FacilityLevel, UpdatedAt = DateTime.Now },
                new Lookup { Id = 31, Name = "Scheduled", LookupType = LookupType.AppointmentStatus, UpdatedAt = DateTime.Now },
                new Lookup { Id = 32, Name = "Attended", LookupType = LookupType.AppointmentStatus, UpdatedAt = DateTime.Now },
                new Lookup { Id = 33, Name = "Missed", LookupType = LookupType.AppointmentStatus, UpdatedAt = DateTime.Now },
                new Lookup { Id = 34, Name = "Attended Else Where", LookupType = LookupType.AppointmentStatus, UpdatedAt = DateTime.Now }
            );

            var bcg = new Immunization
            {
                Id = 1, Name = "BCG",
                Description = "bacille Calmette-Guerin, is a vaccine for tuberculosis (TB) disease",
                Dose = "0.05mls for child below 1 year/0.1mls for child above 1 year",
                AdministrationMode = "Intra- dermal left fore arm", SideEffects = "side effect"
            };
            var polio = new Immunization
            {
                Id = 2, Name = "POLIO VACCINE", Description = "Bivalent Oral Polio Vaccine(bOPV)", Dose = "2 drops",
                AdministrationMode = "orally", SideEffects = "side effect"
            };
            var ipv = new Immunization
            {
                Id = 3, Name = "IPV", Description = "Inactivated Polio Vaccine", Dose = "0.5 mls",
                AdministrationMode =
                    " Intramuscular in the right outer thigh 2.5 cm(2 fingers apart) from the site of PCV10 injection",
                SideEffects = "side effect"
            };
            var pv = new Immunization
            {
                Id = 4, Name = "PNEUMOCOCCAL VACCINE", Description = "PNEUMOCOCCAL VACCINE", Dose = "0.5 mls",
                AdministrationMode = "Intramuscular in the right outer thigh", SideEffects = "side effect"
            };
            var rvv = new Immunization
            {
                Id = 5, Name = "ROTA VIRUS VACCINE (ROTARIX)", Description = "ROTA VIRUS VACCINE (ROTARIX)",
                Dose = "1.5 mls", AdministrationMode = "orally, slowly", SideEffects = "side effect"
            };
            var mrv = new Immunization
            {
                Id = 6, Name = "MEASLES RUBELLA VACCINE (MR)", Description = "MEASLES RUBELLA VACCINE (MR)",
                Dose = "0.5 mls", AdministrationMode = "subcutaneous right upper thigh", SideEffects = "side effect"
            };
            var yellow = new Immunization
            {
                Id = 7,
                Name = "YELLOW FEVER VACCINE ",
                Description = "YELLOW FEVER VACCINE ",
                Dose = "0.5 mls",
                AdministrationMode = "Intra Muscular left upper deltoid",
                SideEffects = "side effect"
            };
            var dpth = new Immunization
            {
                Id = 8,
                Name = "DIPHTHERIA/PERTUSSIS/TETANUS/HEPATITIS B / HAEMOPHILUS INFLUENZA Type b",
                Description = "DIPHTHERIA/PERTUSSIS/TETANUS/HEPATITIS B / HAEMOPHILUS INFLUENZA Type b",
                Dose = "0.5 mls",
                AdministrationMode = "Intra Muscular left upper thigh",
                SideEffects = "side effect"
            };

            modelBuilder.Entity<Immunization>().HasData(
                bcg, polio, ipv, pv, rvv, mrv, yellow, dpth

            );

            modelBuilder.Entity<ImmunizationPeriod>().HasData(
            new ImmunizationPeriod { Id = 1, Duration = 0, Period = Period.Weeks, ImmunizationId = 1},
            new ImmunizationPeriod { Id = 2, Duration = 6, Period = Period.Weeks, ImmunizationId = 2, UpdatedAt = DateTime.Now },
            new ImmunizationPeriod { Id = 3, Duration = 10, Period = Period.Weeks, ImmunizationId = 2, UpdatedAt = DateTime.Now },
            new ImmunizationPeriod { Id = 4, Duration = 14, Period = Period.Weeks, ImmunizationId = 2, UpdatedAt = DateTime.Now },
            new ImmunizationPeriod { Id = 5, Duration = 14, Period = Period.Weeks, ImmunizationId = 3, UpdatedAt = DateTime.Now },
            new ImmunizationPeriod { Id = 6, Duration = 6, Period = Period.Weeks, ImmunizationId = 4, UpdatedAt = DateTime.Now },
            new ImmunizationPeriod { Id = 7, Duration = 10, Period = Period.Weeks, ImmunizationId = 4, UpdatedAt = DateTime.Now },
            new ImmunizationPeriod { Id = 8, Duration = 14, Period = Period.Weeks, ImmunizationId = 4, UpdatedAt = DateTime.Now },
            new ImmunizationPeriod { Id = 9, Duration = 6, Period = Period.Weeks, ImmunizationId = 5, UpdatedAt = DateTime.Now },
            new ImmunizationPeriod { Id = 10, Duration = 10, Period = Period.Weeks, ImmunizationId = 5, UpdatedAt = DateTime.Now },
            new ImmunizationPeriod { Id = 11, Duration = 9, Period = Period.Months, ImmunizationId = 6, UpdatedAt = DateTime.Now },
            new ImmunizationPeriod { Id = 12, Duration = 18, Period = Period.Months, ImmunizationId = 6, UpdatedAt = DateTime.Now },
            new ImmunizationPeriod { Id = 13, Duration = 9, Period = Period.Months, ImmunizationId = 7, UpdatedAt = DateTime.Now },
            new ImmunizationPeriod { Id = 14, Duration = 6, Period = Period.Weeks, ImmunizationId = 8, UpdatedAt = DateTime.Now },
            new ImmunizationPeriod { Id = 15, Duration = 10, Period = Period.Weeks, ImmunizationId = 8, UpdatedAt = DateTime.Now },
            new ImmunizationPeriod { Id = 16, Duration = 14, Period = Period.Weeks, ImmunizationId = 8, UpdatedAt = DateTime.Now }

            );

            modelBuilder.Entity<Facility>().HasData(
                new Facility() { Id = 1,Name = "Kenyatta", MflCode = "MFL-001", CountyId = 24, PostalAddress = "PO Box 123-00100", FacilityLevelId = 28, Location = "Nairobi", Latitude = 0, Longitude = 0}
            );
        }
    }
}