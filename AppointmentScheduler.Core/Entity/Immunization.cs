using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentScheduler.Core.Entity
{
    public class Immunization : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Dose { get; set; }
        public string AdministrationMode { get; set; }
        public string SideEffects { get; set; }
        public ICollection<ImmunizationPeriod> ImmunizationPeriods { get; set; }

    }
}
