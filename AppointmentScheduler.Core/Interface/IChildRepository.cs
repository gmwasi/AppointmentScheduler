using System.Collections.Generic;
using AppointmentScheduler.Core.Entity;

namespace AppointmentScheduler.Core.Interface
{
    public interface IChildRepository : IRepository<Child>
    {
        IEnumerable<Child> GetAllFlattened();
        Child GetAllFlattenedById(int id);
        IEnumerable<Child> Find(string param);
    }
}