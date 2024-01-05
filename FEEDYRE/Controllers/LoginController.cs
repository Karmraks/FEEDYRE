using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FEEDYRE.Core.Abstractions.Extensions;
using FEEDYRE.Core.Abstractions.Interfaces;
using FEEDYRE.Web.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using FEEDYRE.Core.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FEEDYRE.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(IUserRepository userRepository, IConfiguration configuration) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto user)
        {
            var entity = user.ToEntity();

            if (await userRepository.Get(entity) == null)
            {
                return BadRequest(error: JsonSerializer.Serialize("Username and/or Password are incorrect"));
            }

            var token = CreateToken(entity);

            return Ok(token);
        }

        private string CreateToken(User entity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecret = configuration["JwtSecret"]!;
            var key = Encoding.ASCII.GetBytes(jwtSecret);

            var claims = new List<Claim>()
            {
                new (ClaimTypes.Sid, entity.Id.ToString()),
                new (ClaimTypes.Email, entity.Email)
            };

            var identity = new ClaimsIdentity(claims);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
