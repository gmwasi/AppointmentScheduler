using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using AppointmentScheduler.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppointmentScheduler.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly ILogger<AppointmentsController> _logger;
        private readonly IAppointmentService _appointmentService;
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentsController(ILogger<AppointmentsController> logger, IAppointmentService appointmentService, IAppointmentRepository appointmentRepository)
        {
            _logger = logger;
            _appointmentService = appointmentService;
            _appointmentRepository = appointmentRepository;
        }

        [HttpGet]
        public IEnumerable<Appointment> Get()
        {
            return _appointmentRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Appointment GetById(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        [HttpGet("{month}")]
        public IEnumerable<Appointment> GetByMonth(int month)
        {
            return _appointmentRepository.GetByMonth(month);
        }

        [HttpGet("SCHEDULE/{dateOfBirth}")]
        public IEnumerable<AppointmentView> GetAppointmentScheduleFromDob(string dateOfBirth)
        {
            DateTime dob = DateTime.ParseExact(dateOfBirth, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            return _appointmentService.GetAppointmentScheduleFromDob(dob);
        }

        [HttpPost]
        public async Task<IActionResult> Save(List<Appointment> appointments)
        {
            try
            {
                await _appointmentService.SaveAppointments(appointments);
                return Created(new Uri(Request.GetDisplayUrl()), appointments);
            }
            catch (Exception e)
            {
                return BadRequest(e);

            }
        }
    }
}
