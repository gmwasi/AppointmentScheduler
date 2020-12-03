using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentScheduler.Core.Entity
{
    public class Appointment : Entity
    {
        public DateTime AppointmentDate { get; set; }
        public int AppointmentStatus { get; set; } = 31;
        public Immunization Immunization { get; set; }
        public int ImmunizationId { get; set; }
        public Child Child { get; set; }
        public int ChildId { get; set; }

    }
}
