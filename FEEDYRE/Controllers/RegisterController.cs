using FEEDYRE.Core.Abstractions.Interfaces;
using FEEDYRE.Core.Models;
using FEEDYRE.Core.Repositories;
using FEEDYRE.Web.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using FEEDYRE.Core.Abstractions.Extensions;

namespace FEEDYRE.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController(IUserRepository userRepository) : Controller
    {

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto user)
        {
            var entity = user.ToEntity();
            if (await userRepository.IsRegistered(entity))
            {
                return BadRequest(error: JsonSerializer.Serialize("User is already registered"));
            }

            await userRepository.Create(entity);
            return Created("", user);
        }
    }
}
