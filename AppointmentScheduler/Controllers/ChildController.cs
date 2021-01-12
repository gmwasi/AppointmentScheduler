using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using AppointmentScheduler.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppointmentScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            return _childRepository.GetAllFull();
        }

        [HttpGet("{id}")]
        public Child GetById(int id)
        {
            return _childRepository.GetAllFullById(id);
        }

        [HttpGet("FIND")]
        public IEnumerable<Child> FindChild([FromQuery] string param)
        {
            return _childRepository.Find(param);
        }

        [HttpGet("EMAIL/{email}")]
        public Child FindChildByEmail(string email)
        {
            return _childRepository.GetChildByEmail(email);
        }

        [HttpPost("REGISTER")]
        public async Task<IActionResult> Register([FromBody] Registration registration)
        {
            try
            {
                var result = await _childService.Register(registration);
                return Created(new Uri(Request.GetDisplayUrl()), result);
            }
            catch (Exception e)
            {
                return BadRequest(e);

            }
        }
    }
}
