using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentScheduler.Core.Entity
{
    public class ImmunizationPeriod : Entity
    {
        public int Duration { get; set; }
        public Period Period { get; set; }
        public virtual Immunization Immunization { get; set; }
        public int ImmunizationId { get; set; }

    }

    public enum Period
    {
        Days,
        Weeks,
        Months,
        Years

    }
}
