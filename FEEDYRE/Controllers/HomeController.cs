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
            return Ok("HomePage is here");
        }
    }
}
