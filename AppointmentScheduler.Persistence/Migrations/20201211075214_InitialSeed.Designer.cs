﻿// <auto-generated />
using System;
using AppointmentScheduler.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppointmentScheduler.Persistence.Migrations
{
    [DbContext(typeof(AppointmentsContext))]
    [Migration("20201211075214_InitialSeed")]
    partial class InitialSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AppointmentStatus")
                        .HasColumnType("int");

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<int>("ImmunizationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("ImmunizationId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CareGiverId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("UniqueNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CareGiverId")
                        .IsUnique();

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Children");
                });

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CountyId")
                        .HasColumnType("int");

                    b.Property<int>("FacilityLevelId")
                        .HasColumnType("int");

                    b.Property<int>("Latitude")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Longitude")
                        .HasColumnType("int");

                    b.Property<string>("MflCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Facilities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountyId = 24,
                            FacilityLevelId = 28,
                            Latitude = 0,
                            Location = "Nairobi",
                            Longitude = 0,
                            MflCode = "MFL-001",
                            Name = "Kenyatta",
                            PostalAddress = "PO Box 123-00100"
                        });
                });

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.Immunization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AdministrationMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SideEffects")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Immunizations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdministrationMode = "Intra- dermal lef fore arm",
                            Description = "bacille Calmette-Guerin, is a vaccine for tuberculosis (TB) disease",
                            Dose = "0.05mls for child below 1 year/0.1mls for child above 1 year",
                            Name = "BCG",
                            SideEffects = "side effect"
                        },
                        new
                        {
                            Id = 2,
                            AdministrationMode = "orally",
                            Description = "Bivalent Oral Polio Vaccine(bOPV)",
                            Dose = "2 drops",
                            Name = "POLIO VACCINE",
                            SideEffects = "side effect"
                        },
                        new
                        {
                            Id = 3,
                            AdministrationMode = " Intramuscular in the right outer thigh 2.5 cm(2 fingers apart) from the site of PCV10 injection",
                            Description = "Inactivated Polio Vaccine",
                            Dose = "0.5 mls",
                            Name = "IPV",
                            SideEffects = "side effect"
                        },
                        new
                        {
                            Id = 4,
                            AdministrationMode = "Intramuscular in the right outer thigh",
                            Description = "PNEUMOCOCCAL VACCINE",
                            Dose = "0.5 mls",
                            Name = "PNEUMOCOCCAL VACCINE",
                            SideEffects = "side effect"
                        },
                        new
                        {
                            Id = 5,
                            AdministrationMode = "orally, slowly",
                            Description = "ROTA VIRUS VACCINE (ROTARIX)",
                            Dose = "1.5 mls",
                            Name = "ROTA VIRUS VACCINE (ROTARIX)",
                            SideEffects = "side effect"
                        },
                        new
                        {
                            Id = 6,
                            AdministrationMode = "subcutaneous right upper thigh",
                            Description = "MEASLES RUBELLA VACCINE (MR)",
                            Dose = "0.5 mls",
                            Name = "MEASLES RUBELLA VACCINE (MR)",
                            SideEffects = "side effect"
                        },
                        new
                        {
                            Id = 7,
                            AdministrationMode = "Intra Muscular left upper deltoid",
                            Description = "YELLOW FEVER VACCINE ",
                            Dose = "0.5 mls",
                            Name = "YELLOW FEVER VACCINE ",
                            SideEffects = "side effect"
                        },
                        new
                        {
                            Id = 8,
                            AdministrationMode = "Intra Muscular left upper thigh",
                            Description = "DIPHTHERIA/PERTUSSIS/TETANUS/HEPATITIS B / HAEMOPHILUS INFLUENZA Type b",
                            Dose = "0.5 mls",
                            Name = "DIPHTHERIA/PERTUSSIS/TETANUS/HEPATITIS B / HAEMOPHILUS INFLUENZA Type b",
                            SideEffects = "side effect"
                        });
                });

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.ImmunizationPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("ImmunizationId")
                        .HasColumnType("int");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImmunizationId");

                    b.ToTable("ImmunizationPeriods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Duration = 0,
                            ImmunizationId = 1,
                            Period = 1
                        },
                        new
                        {
                            Id = 2,
                            Duration = 6,
                            ImmunizationId = 2,
                            Period = 1
                        },
                        new
                        {
                            Id = 3,
                            Duration = 10,
                            ImmunizationId = 2,
                            Period = 1
                        },
                        new
                        {
                            Id = 4,
                            Duration = 14,
                            ImmunizationId = 2,
                            Period = 1
                        },
                        new
                        {
                            Id = 5,
                            Duration = 14,
                            ImmunizationId = 3,
                            Period = 1
                        },
                        new
                        {
                            Id = 6,
                            Duration = 6,
                            ImmunizationId = 4,
                            Period = 1
                        },
                        new
                        {
                            Id = 7,
                            Duration = 10,
                            ImmunizationId = 4,
                            Period = 1
                        },
                        new
                        {
                            Id = 8,
                            Duration = 14,
                            ImmunizationId = 4,
                            Period = 1
                        },
                        new
                        {
                            Id = 9,
                            Duration = 6,
                            ImmunizationId = 5,
                            Period = 1
                        },
                        new
                        {
                            Id = 10,
                            Duration = 10,
                            ImmunizationId = 5,
                            Period = 1
                        },
                        new
                        {
                            Id = 11,
                            Duration = 9,
                            ImmunizationId = 6,
                            Period = 2
                        },
                        new
                        {
                            Id = 12,
                            Duration = 18,
                            ImmunizationId = 6,
                            Period = 2
                        },
                        new
                        {
                            Id = 13,
                            Duration = 9,
                            ImmunizationId = 7,
                            Period = 2
                        },
                        new
                        {
                            Id = 14,
                            Duration = 6,
                            ImmunizationId = 8,
                            Period = 1
                        },
                        new
                        {
                            Id = 15,
                            Duration = 10,
                            ImmunizationId = 8,
                            Period = 1
                        },
                        new
                        {
                            Id = 16,
                            Duration = 14,
                            ImmunizationId = 8,
                            Period = 1
                        });
                });

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.Lookup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("LookupType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lookups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LookupType = 0,
                            Name = "Male"
                        },
                        new
                        {
                            Id = 2,
                            LookupType = 0,
                            Name = "Female"
                        },
                        new
                        {
                            Id = 3,
                            LookupType = 1,
                            Name = "Single"
                        },
                        new
                        {
                            Id = 4,
                            LookupType = 1,
                            Name = "Married"
                        },
                        new
                        {
                            Id = 5,
                            LookupType = 1,
                            Name = "Divorced"
                        },
                        new
                        {
                            Id = 6,
                            LookupType = 1,
                            Name = "Widow"
                        },
                        new
                        {
                            Id = 7,
                            LookupType = 1,
                            Name = "Widower"
                        },
                        new
                        {
                            Id = 8,
                            LookupType = 3,
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 9,
                            LookupType = 3,
                            Name = "User"
                        },
                        new
                        {
                            Id = 10,
                            LookupType = 3,
                            Name = "CareGiver"
                        },
                        new
                        {
                            Id = 11,
                            LookupType = 4,
                            Name = "Parent"
                        },
                        new
                        {
                            Id = 12,
                            LookupType = 4,
                            Name = "GrandParent"
                        },
                        new
                        {
                            Id = 13,
                            LookupType = 4,
                            Name = "Spouse"
                        },
                        new
                        {
                            Id = 14,
                            LookupType = 4,
                            Name = "Sibling"
                        },
                        new
                        {
                            Id = 15,
                            LookupType = 4,
                            Name = "Child"
                        },
                        new
                        {
                            Id = 16,
                            LookupType = 4,
                            Name = "Aunt"
                        },
                        new
                        {
                            Id = 17,
                            LookupType = 4,
                            Name = "Uncle"
                        },
                        new
                        {
                            Id = 18,
                            LookupType = 4,
                            Name = "Cousin"
                        },
                        new
                        {
                            Id = 19,
                            LookupType = 4,
                            Name = "In-law"
                        },
                        new
                        {
                            Id = 20,
                            LookupType = 4,
                            Name = "CHV"
                        },
                        new
                        {
                            Id = 24,
                            LookupType = 2,
                            Name = "Nairobi"
                        },
                        new
                        {
                            Id = 25,
                            LookupType = 2,
                            Name = "Kilifi"
                        },
                        new
                        {
                            Id = 26,
                            LookupType = 2,
                            Name = "Nyamira"
                        },
                        new
                        {
                            Id = 27,
                            LookupType = 2,
                            Name = "Nakuru"
                        },
                        new
                        {
                            Id = 28,
                            LookupType = 5,
                            Name = "National"
                        },
                        new
                        {
                            Id = 29,
                            LookupType = 5,
                            Name = "County"
                        },
                        new
                        {
                            Id = 30,
                            LookupType = 5,
                            Name = "Sub-County"
                        },
                        new
                        {
                            Id = 31,
                            LookupType = 6,
                            Name = "Scheduled"
                        },
                        new
                        {
                            Id = 32,
                            LookupType = 6,
                            Name = "Attended"
                        },
                        new
                        {
                            Id = 33,
                            LookupType = 6,
                            Name = "Missed"
                        },
                        new
                        {
                            Id = 34,
                            LookupType = 6,
                            Name = "Attended Else Where"
                        });
                });

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("HudumaNamba")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaritalStatusId")
                        .HasColumnType("int");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1995, 12, 11, 0, 0, 0, 0, DateTimeKind.Local),
                            FacilityId = 1,
                            FirstName = "User",
                            GenderId = 1,
                            HudumaNamba = "12345671",
                            LastName = "Doe",
                            MaritalStatusId = 3,
                            MiddleName = "1"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1990, 12, 11, 0, 0, 0, 0, DateTimeKind.Local),
                            FacilityId = 1,
                            FirstName = "User",
                            GenderId = 2,
                            HudumaNamba = "12345672",
                            LastName = "Jil",
                            MaritalStatusId = 3,
                            MiddleName = "2"
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(1980, 12, 11, 0, 0, 0, 0, DateTimeKind.Local),
                            FacilityId = 1,
                            FirstName = "User",
                            GenderId = 1,
                            HudumaNamba = "12345673",
                            LastName = "Don",
                            MaritalStatusId = 4,
                            MiddleName = "3"
                        });
                });

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.PersonContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AlternateNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhysicalAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonContacts");
                });

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.PersonRelative", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhysicalAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RelationshipId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonRelatives");
                });

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

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

                    b.HasIndex("PersonId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.Appointment", b =>
                {
                    b.HasOne("AppointmentScheduler.Core.Entity.Child", "Child")
                        .WithMany()
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppointmentScheduler.Core.Entity.Immunization", "Immunization")
                        .WithMany()
                        .HasForeignKey("ImmunizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Immunization");
                });

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.Child", b =>
                {
                    b.HasOne("AppointmentScheduler.Core.Entity.Person", "CareGiver")
                        .WithOne()
                        .HasForeignKey("AppointmentScheduler.Core.Entity.Child", "CareGiverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AppointmentScheduler.Core.Entity.Person", "Person")
                        .WithOne()
                        .HasForeignKey("AppointmentScheduler.Core.Entity.Child", "PersonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CareGiver");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.ImmunizationPeriod", b =>
                {
                    b.HasOne("AppointmentScheduler.Core.Entity.Immunization", "Immunization")
                        .WithMany("ImmunizationPeriods")
                        .HasForeignKey("ImmunizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Immunization");
                });

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.PersonContact", b =>
                {
                    b.HasOne("AppointmentScheduler.Core.Entity.Person", "Person")
                        .WithMany("PersonContacts")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.PersonRelative", b =>
                {
                    b.HasOne("AppointmentScheduler.Core.Entity.Person", "Person")
                        .WithMany("PersonRelatives")
                        .HasForeignKey("PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.User", b =>
                {
                    b.HasOne("AppointmentScheduler.Core.Entity.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AppointmentScheduler.Core.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AppointmentScheduler.Core.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppointmentScheduler.Core.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AppointmentScheduler.Core.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.Immunization", b =>
                {
                    b.Navigation("ImmunizationPeriods");
                });

            modelBuilder.Entity("AppointmentScheduler.Core.Entity.Person", b =>
                {
                    b.Navigation("PersonContacts");

                    b.Navigation("PersonRelatives");
                });
#pragma warning restore 612, 618
        }
    }
}