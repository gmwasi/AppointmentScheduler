using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentScheduler.Core.Entity
{
    public class Person : Entity
    {
        public string HudumaNamba { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public int MaritalStatusId { get; set; }
        public int FacilityId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<PersonContact> PersonContacts { get; set; }
        public virtual ICollection<PersonRelative> PersonRelatives { get; set; }
    }
}
