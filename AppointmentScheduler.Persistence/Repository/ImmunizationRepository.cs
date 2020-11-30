using System.Collections.Generic;
using System.Linq;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using AppointmentScheduler.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace AppointmentScheduler.Persistence.Repository
{
    public class ImmunizationRepository : Repository<Immunization>, IImmunizationRepository
    {
        private IQueryable<Immunization> _entities;
        public ImmunizationRepository(AppointmentsContext context) : base(context)
        {
            _entities = context.Immunizations.Include(i=>i.ImmunizationPeriods).AsNoTracking();
        }

        public IEnumerable<ImmunizationView> GetAllFlattened()
        {
            var immunizationViews = new List<ImmunizationView>();
            var immunizations = _entities;
            foreach (var immunization in immunizations)
            {
                foreach (var period in immunization.ImmunizationPeriods)
                {
                    var immunizationView = new ImmunizationView()
                    {
                        Id = immunization.Id,
                        Name = immunization.Name,
                        AdministrationMode = immunization.AdministrationMode,
                        Description = immunization.Description,
                        Dose = immunization.Dose,
                        Duration = period.Duration,
                        Period = period.Period,
                        SideEffects = immunization.SideEffects
                    };
                    immunizationViews.Add(immunizationView);
                }
            }

            return immunizationViews;
        }
    }
}
