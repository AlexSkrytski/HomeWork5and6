using Microsoft.AspNetCore.Mvc;

namespace HomeWork5and6.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class HomeWorkTask1Controller : ControllerBase
    {

        [HttpPost("analyze")]
        public ActionResult<string> ArraySum(int[] requestIds)
        {

            try
            {
                if (requestIds.Length == 0)
                {
                    return BadRequest("empty");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error - {ex.Message}");
            }

            int _sum = 0;

            foreach (int item in requestIds)
            {
                _sum += item;
            }

            return Ok($"Sum - {_sum}");

        }
    }
}
