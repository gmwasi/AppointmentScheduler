using System.Security.Claims;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(UserManager<User> userManager, IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsersAsync()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("USERID")]
        public User GetUser()
        {
            var userName = this.User.FindFirstValue(ClaimTypes.Name);
            return _userRepository.GetByUserName(userName);
        }

        [HttpGet("{id}")]
        public User Get(string id)
        {
            return _userRepository.GetById(id);
        }

    }
}
