using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AppointmentScheduler.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    MflCode = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    PostalAddress = table.Column<string>(type: "text", nullable: true),
                    CountyId = table.Column<int>(type: "integer", nullable: false),
                    FacilityLevelId = table.Column<int>(type: "integer", nullable: false),
                    Latitude = table.Column<int>(type: "integer", nullable: false),
                    Longitude = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Immunizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Dose = table.Column<string>(type: "text", nullable: true),
                    AdministrationMode = table.Column<string>(type: "text", nullable: true),
                    SideEffects = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Immunizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lookups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LookupType = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HudumaNamba = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    GenderId = table.Column<int>(type: "integer", nullable: false),
                    MaritalStatusId = table.Column<int>(type: "integer", nullable: false),
                    FacilityId = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImmunizationPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Period = table.Column<int>(type: "integer", nullable: false),
                    ImmunizationId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmunizationPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImmunizationPeriods_Immunizations_ImmunizationId",
                        column: x => x.ImmunizationId,
                        principalTable: "Immunizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniqueNumber = table.Column<string>(type: "text", nullable: true),
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    CareGiverId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Children_Persons_CareGiverId",
                        column: x => x.CareGiverId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Children_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    AlternateNumber = table.Column<string>(type: "text", nullable: true),
                    PostalAddress = table.Column<string>(type: "text", nullable: true),
                    PhysicalAddress = table.Column<string>(type: "text", nullable: true),
                    CountyId = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonContacts_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonRelatives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PostalAddress = table.Column<string>(type: "text", nullable: true),
                    PhysicalAddress = table.Column<string>(type: "text", nullable: true),
                    RelationshipId = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRelatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonRelatives_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AppointmentStatus = table.Column<int>(type: "integer", nullable: false),
                    ImmunizationId = table.Column<int>(type: "integer", nullable: false),
                    ChildId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Immunizations_ImmunizationId",
                        column: x => x.ImmunizationId,
                        principalTable: "Immunizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "CountyId", "CreatedAt", "FacilityLevelId", "Latitude", "Location", "Longitude", "MflCode", "Name", "PostalAddress", "UpdatedAt" },
                values: new object[] { 1, 24, null, 28, 0, "Nairobi", 0, "MFL-001", "Kenyatta", "PO Box 123-00100", null });

            migrationBuilder.InsertData(
                table: "Immunizations",
                columns: new[] { "Id", "AdministrationMode", "CreatedAt", "Description", "Dose", "Name", "SideEffects", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Intra- dermal left fore arm", null, "bacille Calmette-Guerin, is a vaccine for tuberculosis (TB) disease", "0.05mls for child below 1 year/0.1mls for child above 1 year", "BCG", "side effect", null },
                    { 2, "orally", null, "Bivalent Oral Polio Vaccine(bOPV)", "2 drops", "POLIO VACCINE", "side effect", null },
                    { 3, " Intramuscular in the right outer thigh 2.5 cm(2 fingers apart) from the site of PCV10 injection", null, "Inactivated Polio Vaccine", "0.5 mls", "IPV", "side effect", null },
                    { 4, "Intramuscular in the right outer thigh", null, "PNEUMOCOCCAL VACCINE", "0.5 mls", "PNEUMOCOCCAL VACCINE", "side effect", null },
                    { 5, "orally, slowly", null, "ROTA VIRUS VACCINE (ROTARIX)", "1.5 mls", "ROTA VIRUS VACCINE (ROTARIX)", "side effect", null },
                    { 6, "subcutaneous right upper thigh", null, "MEASLES RUBELLA VACCINE (MR)", "0.5 mls", "MEASLES RUBELLA VACCINE (MR)", "side effect", null },
                    { 7, "Intra Muscular left upper deltoid", null, "YELLOW FEVER VACCINE ", "0.5 mls", "YELLOW FEVER VACCINE ", "side effect", null },
                    { 8, "Intra Muscular left upper thigh", null, "DIPHTHERIA/PERTUSSIS/TETANUS/HEPATITIS B / HAEMOPHILUS INFLUENZA Type b", "0.5 mls", "DIPHTHERIA/PERTUSSIS/TETANUS/HEPATITIS B / HAEMOPHILUS INFLUENZA Type b", "side effect", null }
                });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedAt", "LookupType", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 18, null, 4, "Cousin", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2328) },
                    { 19, null, 4, "In-law", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2329) },
                    { 20, null, 4, "CHV", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2330) },
                    { 24, null, 2, "Nairobi", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2332) },
                    { 25, null, 2, "Kilifi", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2333) },
                    { 26, null, 2, "Nyamira", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2334) },
                    { 30, null, 5, "Sub-County", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2340) },
                    { 28, null, 5, "National", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2337) },
                    { 29, null, 5, "County", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2339) },
                    { 17, null, 4, "Uncle", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2326) },
                    { 31, null, 6, "Scheduled", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2342) },
                    { 32, null, 6, "Attended", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2343) },
                    { 27, null, 2, "Nakuru", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2336) },
                    { 16, null, 4, "Aunt", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2325) },
                    { 11, null, 4, "Parent", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2317) },
                    { 14, null, 4, "Sibling", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2322) },
                    { 13, null, 4, "Spouse", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2320) },
                    { 12, null, 4, "GrandParent", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2319) },
                    { 33, null, 6, "Missed", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2344) },
                    { 10, null, 3, "CareGiver", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2315) },
                    { 9, null, 3, "User", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2314) },
                    { 8, null, 3, "Administrator", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2313) },
                    { 7, null, 1, "Widower", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2311) },
                    { 6, null, 1, "Widow", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2307) },
                    { 5, null, 1, "Divorced", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2306) },
                    { 4, null, 1, "Married", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2305) },
                    { 3, null, 1, "Single", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2302) },
                    { 2, null, 0, "Female", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2277) },
                    { 1, null, 0, "Male", new DateTime(2021, 1, 12, 13, 23, 16, 658, DateTimeKind.Local).AddTicks(4154) },
                    { 15, null, 4, "Child", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2323) },
                    { 34, null, 6, "Attended Else Where", new DateTime(2021, 1, 12, 13, 23, 16, 659, DateTimeKind.Local).AddTicks(2346) }
                });

            migrationBuilder.InsertData(
                table: "ImmunizationPeriods",
                columns: new[] { "Id", "CreatedAt", "Duration", "ImmunizationId", "Period", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, 0, 1, 1, null },
                    { 2, null, 6, 2, 1, new DateTime(2021, 1, 12, 13, 23, 16, 660, DateTimeKind.Local).AddTicks(6060) },
                    { 3, null, 10, 2, 1, new DateTime(2021, 1, 12, 13, 23, 16, 660, DateTimeKind.Local).AddTicks(6071) },
                    { 4, null, 14, 2, 1, new DateTime(2021, 1, 12, 13, 23, 16, 660, DateTimeKind.Local).AddTicks(6073) },
                    { 5, null, 14, 3, 1, new DateTime(2021, 1, 12, 13, 23, 16, 660, DateTimeKind.Local).AddTicks(6074) },
                    { 6, null, 6, 4, 1, new DateTime(2021, 1, 12, 13, 23, 16, 660, DateTimeKind.Local).AddTicks(6076) },
                    { 7, null, 10, 4, 1, new DateTime(2021, 1, 12, 13, 23, 16, 660, DateTimeKind.Local).AddTicks(6077) },
                    { 8, null, 14, 4, 1, new DateTime(2021, 1, 12, 13, 23, 16, 660, DateTimeKind.Local).AddTicks(6078) },
                    { 9, null, 6, 5, 1, new DateTime(2021, 1, 12, 13, 23, 16, 660, DateTimeKind.Local).AddTicks(6080) },
                    { 10, null, 10, 5, 1, new DateTime(2021, 1, 12, 13, 23, 16, 660, DateTimeKind.Local).AddTicks(6081) },
                    { 11, null, 9, 6, 2, new DateTime(2021, 1, 12, 13, 23, 16, 660, DateTimeKind.Local).AddTicks(6083) },
                    { 12, null, 18, 6, 2, new DateTime(2021, 1, 12, 13, 23, 16, 660, DateTimeKind.Local).AddTicks(6084) },
                    { 13, null, 9, 7, 2, new DateTime(2021, 1, 12, 13, 23, 16, 660, DateTimeKind.Local).AddTicks(6086) },
                    { 14, null, 6, 8, 1, new DateTime(2021, 1, 12, 13, 23, 16, 660, DateTimeKind.Local).AddTicks(6087) },
                    { 15, null, 10, 8, 1, new DateTime(2021, 1, 12, 13, 23, 16, 660, DateTimeKind.Local).AddTicks(6089) },
                    { 16, null, 14, 8, 1, new DateTime(2021, 1, 12, 13, 23, 16, 660, DateTimeKind.Local).AddTicks(6090) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ChildId",
                table: "Appointments",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ImmunizationId",
                table: "Appointments",
                column: "ImmunizationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonId",
                table: "AspNetUsers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Children_CareGiverId",
                table: "Children",
                column: "CareGiverId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Children_PersonId",
                table: "Children",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImmunizationPeriods_ImmunizationId",
                table: "ImmunizationPeriods",
                column: "ImmunizationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_PersonId",
                table: "PersonContacts",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRelatives_PersonId",
                table: "PersonRelatives",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "ImmunizationPeriods");

            migrationBuilder.DropTable(
                name: "Lookups");

            migrationBuilder.DropTable(
                name: "PersonContacts");

            migrationBuilder.DropTable(
                name: "PersonRelatives");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Immunizations");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
