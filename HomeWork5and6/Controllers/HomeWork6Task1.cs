using Microsoft.AspNetCore.Mvc;

namespace HomeWork5and6.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class HomeWorkTask1Controller : ControllerBase
    {

        private int _sum;

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

            foreach (int item in requestIds)
            {
                _sum += item;
            }


            return Ok($"Sum - {_sum}");

        }

    }
}
