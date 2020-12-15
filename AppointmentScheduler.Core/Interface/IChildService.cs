using System.Collections.Generic;
using System.Threading.Tasks;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Model;

namespace AppointmentScheduler.Core.Interface
{
    public interface IChildService
    {
        Task<Child> Register(Registration registration);
    }
}