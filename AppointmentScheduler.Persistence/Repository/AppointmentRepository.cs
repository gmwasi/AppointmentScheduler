using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.Persistence.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private DbSet<Appointment> _entities;
        public AppointmentRepository(AppointmentsContext context) : base(context)
        {
            _entities = context.Set<Appointment>();
        }

        public IEnumerable<Appointment> GetByMonth(int month)
        {
            var appointments = _entities.Where(e => e.AppointmentDate.Month == month).AsEnumerable();
            return appointments;
        }
    }
}
