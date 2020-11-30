using System;

namespace AppointmentScheduler.Core.Model
{
    public class AppointmentView
    {
        public DateTime AppointmentDate { get; set; }
        public int ImmunizationId { get; set; }
        public string ImmunizationName { get; set; }
    }
}