using System.Collections.Generic;
using System.Threading.Tasks;
using AppointmentScheduler.Core.Model;

namespace AppointmentScheduler.Core.Interface
{
    public interface IChildService
    {
        Task<bool> Register(Registration registration);
    }
}