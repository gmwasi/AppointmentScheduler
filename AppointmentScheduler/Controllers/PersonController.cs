using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using AppointmentScheduler.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppointmentScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<LookupController> _logger;
        private readonly IPersonRepository _personRepository;
        private readonly IChildService _childService;

        public PersonController(ILogger<LookupController> logger, IPersonRepository personRepository, IChildService childService)
        {
            _logger = logger;
            _personRepository = personRepository;
            _childService = childService;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _personRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Person GetById(int id)
        {
            return _personRepository.GetById(id);
        }
    }
}
