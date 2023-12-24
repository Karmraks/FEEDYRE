using FEEDYRE.Core.Abstractions.Interfaces;
using FEEDYRE.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FEEDYRE.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserRepository  userRepository) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await userRepository.GetAll();

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            await userRepository.Create(user);

            return Created("",user);
        }
    }
}
