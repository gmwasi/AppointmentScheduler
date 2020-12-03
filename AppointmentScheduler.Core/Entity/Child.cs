namespace AppointmentScheduler.Core.Entity
{
    public class Child : Entity
    {
        public string UniqueNumber { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public int CareGiverId { get; set; }
        public virtual Person CareGiver { get; set; }
    }
}