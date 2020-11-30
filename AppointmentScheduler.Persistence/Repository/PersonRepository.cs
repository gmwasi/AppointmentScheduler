using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.Persistence.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private DbSet<Person> _entities;
        public PersonRepository(AppointmentsContext context) : base(context)
        {
            _entities = context.Set<Person>();
        }
    }
}
