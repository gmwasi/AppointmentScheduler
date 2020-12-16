using System;

namespace AppointmentScheduler.Core.Model
{
    public class AppointmentModel
    {
        public DateTime AppointmentDate { get; set; }
        public bool Attended { get; set; }
        public int ImmunizationId { get; set; }
        public int ChildId { get; set; }
    }
}