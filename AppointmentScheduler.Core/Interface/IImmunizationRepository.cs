using System.Collections.Generic;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Model;

namespace AppointmentScheduler.Core.Interface
{
    public interface IImmunizationRepository : IRepository<Immunization>
    {
        IEnumerable<ImmunizationView> GetAllFlattened();
    }
}
