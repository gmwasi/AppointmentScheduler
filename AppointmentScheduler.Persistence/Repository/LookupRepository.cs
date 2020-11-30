using System.Collections.Generic;
using System.Linq;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.Persistence.Repository
{
    public class LookupRepository : Repository<Lookup>, ILookupRepository
    {
        private readonly DbSet<Lookup> _entities;
        public LookupRepository(AppointmentsContext context) : base(context)
        {
            _entities = context.Set<Lookup>();
        }

        public IEnumerable<Lookup> GetByType(LookupType type)
        {
            return _entities.Where(s => s.LookupType == type);
        }
    }
}
