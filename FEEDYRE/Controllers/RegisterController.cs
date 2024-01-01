using AutoMapper;
using FEEDYRE.Core.Abstractions.Interfaces;
using FEEDYRE.Core.Models;
using FEEDYRE.Core.Repositories;
using FEEDYRE.Web.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FEEDYRE.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController(IUserRepository userRepository, IMapper mapper) : Controller
    {

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto user)
        {
            var entity = mapper.Map<User>(user);
            await userRepository.Create(entity);

            return Created("", entity);
        }
    }
}
