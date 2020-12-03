using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentScheduler.Core.Entity
{
    public class PersonContact : Entity
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AlternateNumber { get; set; }
        public string PostalAddress { get; set; }
        public string PhysicalAddress { get; set; }
        public int CountyId { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
