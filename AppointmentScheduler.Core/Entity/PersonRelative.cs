using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentScheduler.Core.Entity
{
    public class PersonRelative : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalAddress { get; set; }
        public string PhysicalAddress { get; set; }
        public int RelationshipId { get; set; }
        public virtual Person Person { get; set; }
    }
}
