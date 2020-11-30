using AppointmentScheduler.Core.Entity;

namespace AppointmentScheduler.Core.Model
{
    public class ImmunizationView : Entity.Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Dose { get; set; }
        public string AdministrationMode { get; set; }
        public string SideEffects { get; set; }
        public int Duration { get; set; }
        public Period Period { get; set; }
    }
}