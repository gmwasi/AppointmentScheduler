using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.Persistence.Repository
{
    public class FacilityRepository : Repository<Facility>, IFacilityRepository
    {
        private DbSet<Facility> _entities;
        public FacilityRepository(AppointmentsContext context) : base(context)
        {
            _entities = context.Set<Facility>();
        }
    }
}
