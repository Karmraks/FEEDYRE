using FEEDYRE.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FEEDYRE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new List<User>()
            {
                new User(){ Name = "Tarik" },
                new User(){ Name = "WhoAmI" }
            };

            return Ok(users);
        }
    }
}
