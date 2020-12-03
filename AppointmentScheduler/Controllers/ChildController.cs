using System;
using System.Collections.Generic;
using System.Linq;
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
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly ILogger<LookupController> _logger;
        private readonly IChildRepository _childRepository;
        private readonly IChildService _childService;

        public ChildController(IChildRepository childRepository, ILogger<LookupController> logger, IChildService childService)
        {
            _childRepository = childRepository;
            _logger = logger;
            _childService = childService;
        }

        [HttpGet]
        public IEnumerable<Child> Get()
        {
            return _childRepository.GetAllFlattened();
        }

        [HttpGet("{id}")]
        public Child GetById(int id)
        {
            return _childRepository.GetAllFlattenedById(id);
        }

        [HttpGet("FIND")]
        public IEnumerable<Child> FindChild([FromQuery] string param)
        {
            return _childRepository.Find(param);
        }

        [HttpPost("REGISTER")]
        public async Task<IActionResult> Register([FromBody] Registration registration)
        {
            try
            {
                await _childService.Register(registration);
                return Created(new Uri(Request.GetDisplayUrl()), registration);
            }
            catch (Exception e)
            {
                return BadRequest(e);

            }
        }
    }
}
