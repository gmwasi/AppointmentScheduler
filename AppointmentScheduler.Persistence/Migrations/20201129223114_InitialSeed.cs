using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentScheduler.Persistence.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 17, 4, "Uncle" },
                    { 18, 4, "Cousin" },
                    { 19, 4, "In-law" },
                    { 24, 2, "Nairobi" },
                    { 25, 2, "Kilifi" },
                    { 26, 2, "Nyamira" },
                    { 30, 5, "Sub-County" },
                    { 28, 5, "National" },
                    { 29, 5, "County" },
                    { 16, 4, "Aunt" },
                    { 31, 6, "Scheduled" },
                    { 32, 6, "Attended" },
                    { 27, 2, "Nakuru" },
                    { 15, 4, "Child" },
                    { 11, 4, "Parent" },
                    { 13, 4, "Spouse" },
                    { 12, 4, "GrandParent" },
                    { 33, 6, "Missed" },
                    { 10, 3, "CareGiver" },
                    { 9, 3, "User" },
                    { 8, 3, "Administrator" },
                    { 7, 1, "Widower" },
                    { 6, 1, "Widow" },
                    { 5, 1, "Divorced" },
                    { 4, 1, "Married" },
                    { 3, 1, "Single" },
                    { 2, 0, "Female" },
                    { 1, 0, "Male" },
                    { 14, 4, "Sibling" },
                    { 34, 6, "Attended Else Where" }
                });

            migrationBuilder.InsertData(
                table: "ImmunizationPeriods",
                columns: new[] { "Id", "Duration", "ImmunizationId", "Period" },
                values: new object[,]
                {
                    { 1, 0, 1, 1 },
                    { 2, 6, 2, 1 },
                    { 3, 10, 2, 1 },
                    { 4, 14, 2, 1 },
                    { 5, 14, 3, 1 },
                    { 6, 6, 4, 1 },
                    { 7, 10, 4, 1 },
                    { 8, 14, 4, 1 },
                    { 9, 6, 5, 1 },
                    { 10, 10, 5, 1 },
                    { 11, 9, 6, 2 },
                    { 12, 18, 6, 2 },
                    { 13, 9, 7, 2 },
                    { 14, 6, 8, 1 },
                    { 15, 10, 8, 1 },
                    { 16, 14, 8, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
