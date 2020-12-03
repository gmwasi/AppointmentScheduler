using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentScheduler.Persistence.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "CountyId", "FacilityLevelId", "Latitude", "Location", "Longitude", "MflCode", "Name", "PostalAddress" },
                values: new object[] { 1, 24, 28, 0, "Nairobi", 0, "MFL-001", "Kenyatta", "PO Box 123-00100" });

            migrationBuilder.InsertData(
                table: "Immunizations",
                columns: new[] { "Id", "AdministrationMode", "Description", "Dose", "Name", "SideEffects" },
                values: new object[,]
                {
                    { 1, "Intra- dermal lef fore arm", "bacille Calmette-Guerin, is a vaccine for tuberculosis (TB) disease", "0.05mls for child below 1 year/0.1mls for child above 1 year", "BCG", "side effect" },
                    { 2, "orally", "Bivalent Oral Polio Vaccine(bOPV)", "2 drops", "POLIO VACCINE", "side effect" },
                    { 3, " Intramuscular in the right outer thigh 2.5 cm(2 fingers apart) from the site of PCV10 injection", "Inactivated Polio Vaccine", "0.5 mls", "IPV", "side effect" },
                    { 4, "Intramuscular in the right outer thigh", "PNEUMOCOCCAL VACCINE", "0.5 mls", "PNEUMOCOCCAL VACCINE", "side effect" },
                    { 5, "orally, slowly", "ROTA VIRUS VACCINE (ROTARIX)", "1.5 mls", "ROTA VIRUS VACCINE (ROTARIX)", "side effect" },
                    { 6, "subcutaneous right upper thigh", "MEASLES RUBELLA VACCINE (MR)", "0.5 mls", "MEASLES RUBELLA VACCINE (MR)", "side effect" },
                    { 7, "Intra Muscular left upper deltoid", "YELLOW FEVER VACCINE ", "0.5 mls", "YELLOW FEVER VACCINE ", "side effect" },
                    { 8, "Intra Muscular left upper thigh", "DIPHTHERIA/PERTUSSIS/TETANUS/HEPATITIS B / HAEMOPHILUS INFLUENZA Type b", "0.5 mls", "DIPHTHERIA/PERTUSSIS/TETANUS/HEPATITIS B / HAEMOPHILUS INFLUENZA Type b", "side effect" }
                });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "LookupType", "Name" },
                values: new object[,]
                {
                    { 19, 4, "In-law" },
                    { 20, 4, "CHV" },
                    { 24, 2, "Nairobi" },
                    { 25, 2, "Kilifi" },
                    { 26, 2, "Nyamira" },
                    { 27, 2, "Nakuru" },
                    { 32, 6, "Attended" },
                    { 29, 5, "County" },
                    { 30, 5, "Sub-County" },
                    { 31, 6, "Scheduled" },
                    { 18, 4, "Cousin" },
                    { 33, 6, "Missed" },
                    { 34, 6, "Attended Else Where" },
                    { 28, 5, "National" },
                    { 17, 4, "Uncle" },
                    { 13, 4, "Spouse" },
                    { 15, 4, "Child" },
                    { 1, 0, "Male" },
                    { 2, 0, "Female" },
                    { 3, 1, "Single" },
                    { 4, 1, "Married" },
                    { 5, 1, "Divorced" },
                    { 6, 1, "Widow" },
                    { 16, 4, "Aunt" },
                    { 7, 1, "Widower" },
                    { 9, 3, "User" },
                    { 10, 3, "CareGiver" },
                    { 11, 4, "Parent" },
                    { 12, 4, "GrandParent" },
                    { 14, 4, "Sibling" },
                    { 8, 3, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "DateOfBirth", "FacilityId", "FirstName", "GenderId", "LastName", "MaritalStatusId", "MiddleName" },
                values: new object[,]
                {
                    { 2, new DateTime(1990, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), 1, "User", 2, "Jil", 3, "2" },
                    { 1, new DateTime(1995, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), 1, "User", 1, "Doe", 3, "1" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "DateOfBirth", "FacilityId", "FirstName", "GenderId", "LastName", "MaritalStatusId", "MiddleName" },
                values: new object[] { 3, new DateTime(1980, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), 1, "User", 1, "Don", 4, "3" });

            migrationBuilder.InsertData(
                table: "ImmunizationPeriods",
                columns: new[] { "Id", "Duration", "ImmunizationId", "Period" },
                values: new object[,]
                {
                    { 1, 0, 1, 1 },
                    { 16, 14, 8, 1 },
                    { 15, 10, 8, 1 },
                    { 14, 6, 8, 1 },
                    { 13, 9, 7, 2 },
                    { 12, 18, 6, 2 },
                    { 11, 9, 6, 2 },
                    { 9, 6, 5, 1 },
                    { 10, 10, 5, 1 },
                    { 7, 10, 4, 1 },
                    { 6, 6, 4, 1 },
                    { 5, 14, 3, 1 },
                    { 4, 14, 2, 1 },
                    { 3, 10, 2, 1 },
                    { 2, 6, 2, 1 },
                    { 8, 14, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "PersonId", "RoleId", "UserName" },
                values: new object[,]
                {
                    { 2, "jil@app.com", "secret", 2, 9, "jil" },
                    { 1, "doe@app.com", "secret", 1, 8, "doe" },
                    { 3, "don@app.com", "secret", 3, 10, "don" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ImmunizationPeriods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ImmunizationPeriods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ImmunizationPeriods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ImmunizationPeriods",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ImmunizationPeriods",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ImmunizationPeriods",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ImmunizationPeriods",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ImmunizationPeriods",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ImmunizationPeriods",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ImmunizationPeriods",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ImmunizationPeriods",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ImmunizationPeriods",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ImmunizationPeriods",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ImmunizationPeriods",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ImmunizationPeriods",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ImmunizationPeriods",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Immunizations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Immunizations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Immunizations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Immunizations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Immunizations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Immunizations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Immunizations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Immunizations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
