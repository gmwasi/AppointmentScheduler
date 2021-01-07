using System.Collections.Generic;
using System.Linq;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.Persistence.Repository
{
    public class ChildRepository : Repository<Child>, IChildRepository
    {
        private readonly IQueryable<Child> _entities;
        public ChildRepository(AppointmentsContext context) : base(context)
        {
            _entities = context.Children
                .Include(i => i.Person)
                .Include(i => i.Person.PersonContacts)
                .Include(i => i.Person.PersonRelatives)
                .Include(i => i.CareGiver)
                .Include(i => i.CareGiver.PersonContacts)
                .Include(i => i.CareGiver.PersonRelatives)
                .AsNoTracking();
        }

        public IEnumerable<Child> GetAllFull()
        {
            return _entities;
        }

        public Child GetAllFullById(int id)
        {
            return _entities.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<Child> Find(string param)
        {
            return _entities.Where(x =>
                    x.Person.FirstName.Contains(param) || x.Person.MiddleName.Contains(param) || x.Person.LastName.Contains(param) ||
                    x.CareGiver.FirstName.Contains(param) || x.CareGiver.MiddleName.Contains(param) || x.CareGiver.LastName.Contains(param) ||
                    x.UniqueNumber.Contains(param) || x.Person.HudumaNamba.Contains(param) || x.CareGiver.HudumaNamba.Contains(param)
                    )
                .AsEnumerable();
        }

        public Child GetChildByEmail(string email)
        {
            return _entities.Where(x =>
                    x.Person.PersonContacts.FirstOrDefault().Email.Contains(email) || x.CareGiver.PersonContacts.FirstOrDefault().Email.Contains(email)
                    ).FirstOrDefault();
        }
    }
}