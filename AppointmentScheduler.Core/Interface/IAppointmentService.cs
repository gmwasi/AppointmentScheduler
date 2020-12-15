using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Model;

namespace AppointmentScheduler.Core.Interface
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentView> GetAppointmentScheduleFromDob(DateTime dob);
        Task<bool> SaveAppointments(List<Appointment> appointments);

        Task<bool> UpdateStatus(int appointmentId, int status);

        Task<bool> UpdateAppointmentDate(int appointmentId, DateTime date);
    }
}