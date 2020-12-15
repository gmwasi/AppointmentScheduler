using System;
using System.Collections.Generic;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppointmentScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImmunizationsController : ControllerBase
    {
        private readonly ILogger<ImmunizationsController> _logger;
        private readonly IImmunizationRepository _immunizationRepository;

        public ImmunizationsController(ILogger<ImmunizationsController> logger, IImmunizationRepository immunizationRepository)
        {
            _logger = logger;
            _immunizationRepository = immunizationRepository;
        }

        [HttpGet]
        public IEnumerable<Immunization> Get()
        {
            return _immunizationRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Immunization GetById(int id)
        {
            return _immunizationRepository.GetById(id);
        }
    }
}
