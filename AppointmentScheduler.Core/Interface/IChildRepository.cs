using System.Collections.Generic;
using AppointmentScheduler.Core.Entity;

namespace AppointmentScheduler.Core.Interface
{
    public interface IChildRepository : IRepository<Child>
    {
        IEnumerable<Child> GetAllFull();
        Child GetAllFullById(int id);
        IEnumerable<Child> Find(string param);
        Child GetChildByEmail(string email);
    }
}