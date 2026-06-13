using Microsoft.AspNetCore.Mvc;

namespace HomeWork5and6.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        [HttpPost("adminvalidation")]
        public ActionResult AdminValidation([FromBody] string user)
        {

            if (string.Equals(user, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Ok("Signed in as Admin!");
            }

            return BadRequest("Invalid role!");

        }
    }
}
