using System.Collections.Generic;
using AppointmentScheduler.Core.Entity;

namespace AppointmentScheduler.Core.Interface
{
    public interface ILookupRepository : IRepository<Lookup>
    {
        IEnumerable<Lookup> GetByType(LookupType type);
    }
}
