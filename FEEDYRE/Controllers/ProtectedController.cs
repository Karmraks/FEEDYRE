using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FEEDYRE.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var sIdClaim = User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Sid);

            var id = sIdClaim!.Value;


            var data = $"THIS IS BIG SECRET FOR YOU MY User with ID : {id}";

            return Ok(data);
        }
    }
}
