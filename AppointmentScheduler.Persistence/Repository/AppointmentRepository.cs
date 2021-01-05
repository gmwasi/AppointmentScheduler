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
        private readonly IQueryable<Appointment> _entities;
        public AppointmentRepository(AppointmentsContext context) : base(context)
        {
            _entities = context.Set<Appointment>();
            _entities = context.Appointments
                .Include(i => i.Immunization)
                .Include(i => i.Child)
                .Include(i => i.Child.Person)
                .Include(i=> i.Child.CareGiver)
                .Include(i => i.Child.CareGiver.PersonContacts)
                .Include(i => i.Child.Person.PersonContacts)
                .AsNoTracking();
        }

        public Appointment GetByIdFull(int id)
        {
            return _entities.SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<Appointment> GetAllFull()
        {
            return _entities;
        }

        public IEnumerable<Appointment> GetByMonth(int month)
        {
            var appointments = _entities.Where(e => e.AppointmentDate.Month == month).AsEnumerable();
            return appointments;
        }

    }
}
