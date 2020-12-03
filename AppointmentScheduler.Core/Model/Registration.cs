using AppointmentScheduler.Core.Entity;

namespace AppointmentScheduler.Core.Model
{
    public class Registration
    {
        public PersonRegistration Child { get; set; }
        public PersonRegistration CareGiver { get; set; }
        public PersonContact Contact { get; set; }
        public PersonRelative Relative { get; set; }

    }
}