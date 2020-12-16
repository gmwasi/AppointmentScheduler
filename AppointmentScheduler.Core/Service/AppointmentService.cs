using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using AppointmentScheduler.Core.Model;

namespace AppointmentScheduler.Core.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IImmunizationRepository _immunizationRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IImmunizationRepository immunizationRepository, IAppointmentRepository appointmentRepository)
        {
            _immunizationRepository = immunizationRepository;
            _appointmentRepository = appointmentRepository;
        }

        public IEnumerable<AppointmentView> GetAppointmentScheduleFromDob(DateTime dob)
        {
            var appointmentViews = new List<AppointmentView>();
            var immunizations = _immunizationRepository.GetAllFlattened();
            foreach (var immunization in immunizations)
            {
                DateTime appointmentDate = CalculateDate(dob, immunization.Period, immunization.Duration);

                var appointmentView = new AppointmentView()
                {
                    ImmunizationId = immunization.Id,
                    ImmunizationName = immunization.Name,
                    AppointmentDate = appointmentDate
                };
                appointmentViews.Add(appointmentView);

            }

            var result = appointmentViews.OrderBy(x => x.AppointmentDate);
            return result;
        }

        public async Task<bool> SaveAppointments(List<AppointmentModel> appointmentModels)
        {
            try
            {
                foreach (var appointmentModel in appointmentModels)
                {
                    var appointment = new Appointment()
                    {
                        AppointmentDate = appointmentModel.AppointmentDate,
                        AppointmentStatus = appointmentModel.Attended ? 32 : 31,
                        ChildId = appointmentModel.ChildId,
                        ImmunizationId = appointmentModel.ImmunizationId,
                    };
                    await Task.Run(() => _appointmentRepository.Insert(appointment));
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> UpdateStatus(int appointmentId, int status)
        {
            try
            {
                var appointment = _appointmentRepository.GetById(appointmentId);
                appointment.AppointmentStatus = status;
                await Task.Run(() => _appointmentRepository.Update(appointment));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> UpdateAppointmentDate(int appointmentId, DateTime date)
        {
            try
            {
                var appointment = _appointmentRepository.GetById(appointmentId);
                appointment.AppointmentDate = date;
                await Task.Run(() => _appointmentRepository.Update(appointment));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private DateTime CalculateDate(DateTime dob, Period period, int duration)
        {
            var appointmentDate = dob;
            if (period == Period.Days)
            {
                appointmentDate = dob.AddDays(duration);
            }
            else if (period == Period.Weeks)
            {
                appointmentDate = dob.AddDays(duration * 7);
            }
            else if (period == Period.Months)
            {
                appointmentDate = dob.AddMonths(duration);
            }
            else if (period == Period.Years)
            {
                appointmentDate = dob.AddYears(duration);
            }
            return appointmentDate;
        }
    }
}