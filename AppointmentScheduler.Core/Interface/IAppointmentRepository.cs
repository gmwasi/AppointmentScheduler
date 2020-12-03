using System.Collections.Generic;
using AppointmentScheduler.Core.Entity;

namespace AppointmentScheduler.Core.Interface
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Appointment GetByIdFull(int id);
        IEnumerable<Appointment> GetAllFull();
        IEnumerable<Appointment> GetByMonth(int month);
    }
}
