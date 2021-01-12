using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppointmentScheduler.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LookupController : ControllerBase
    {
        private readonly ILogger<LookupController> _logger;
        private readonly ILookupRepository _lookupRepository;

        public LookupController(ILogger<LookupController> logger, ILookupRepository lookupRepository)
        {
            _logger = logger;
            _lookupRepository = lookupRepository;
        }

        [HttpGet("TYPE/{type}")]
        public IEnumerable<Lookup> GetByType(int type)
        {
            LookupType lookupType = (LookupType)type;
            return _lookupRepository.GetByType(lookupType);
        }

        [HttpGet("GENDER")]
        public IEnumerable<Lookup> GetGender()
        {
            return _lookupRepository.GetByType(LookupType.Gender);
        }

        [HttpGet("MARITALSTATUS")]
        public IEnumerable<Lookup> GetMaritalStatus()
        {
            return _lookupRepository.GetByType(LookupType.MaritalStatus);
        }

        [HttpGet("COUNTY")]
        public IEnumerable<Lookup> GetCounty()
        {
            return _lookupRepository.GetByType(LookupType.County);
        }

        [HttpGet("ROLE")]
        public IEnumerable<Lookup> GetRole()
        {
            return _lookupRepository.GetByType(LookupType.Role);
        }

        [HttpGet("RELATIONSHIP")]
        public IEnumerable<Lookup> GetRelationship()
        {
            return _lookupRepository.GetByType(LookupType.Relationship);
        }

        [HttpGet("FACILITYLEVEL")]
        public IEnumerable<Lookup> GetFacilityLevel()
        {
            return _lookupRepository.GetByType(LookupType.FacilityLevel);
        }

        [HttpGet("APPOINTMENTSTATUS")]
        public IEnumerable<Lookup> GetAppointmentStatus()
        {
            return _lookupRepository.GetByType(LookupType.AppointmentStatus);
        }

        [HttpGet("APPOINTMENTSTATUSMARK")]
        public IEnumerable<Lookup> GetMarkAppointmentStatus()
        {
            return _lookupRepository.GetByType(LookupType.AppointmentStatus).Where(x => x.Name.Contains("Attend"));
        }
    }
}
