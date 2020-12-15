using System;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Persistence.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.Persistence
{
    public class AppointmentsContext : IdentityDbContext<User> 
    {
        public AppointmentsContext(DbContextOptions<AppointmentsContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonContact> PersonContacts { get; set; }
        public DbSet<PersonRelative> PersonRelatives { get; set; }
        public DbSet<Lookup> Lookups { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Immunization> Immunizations { get; set; }
        public DbSet<ImmunizationPeriod> ImmunizationPeriods { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Child> Children { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                .HasMany(c => c.PersonContacts)
                .WithOne(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasMany(c => c.PersonRelatives)
                .WithOne(e => e.Person);

            modelBuilder.Entity<Immunization>()
                .HasMany(c => c.ImmunizationPeriods)
                .WithOne(e => e.Immunization);

            modelBuilder.Entity<User>()
                .HasOne(c => c.Person);

            modelBuilder.Entity<Appointment>()
                .HasOne(c => c.Immunization);
            modelBuilder.Entity<Child>()
                .HasOne(c => c.Person).WithOne().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Child>()
                .HasOne(c => c.CareGiver).WithOne().OnDelete(DeleteBehavior.NoAction);

                modelBuilder.Seed();
        }
    }
}