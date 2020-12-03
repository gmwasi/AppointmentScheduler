using System;
using AppointmentScheduler.Core.Entity;

namespace AppointmentScheduler.Core.Model
{
    public class PersonRegistration : Entity.Entity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public int MaritalStatusId { get; set; }
        public int FacilityId { get; set; }
        public string UniqueNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}