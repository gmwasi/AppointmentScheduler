using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.Persistence.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private DbSet<User> _entities;
        public UserRepository(AppointmentsContext context) : base(context)
        {
            _entities = context.Set<User>();
        }
    }
}
