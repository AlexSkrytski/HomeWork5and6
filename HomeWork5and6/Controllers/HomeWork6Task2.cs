using Microsoft.AspNetCore.Mvc;

namespace HomeWork5and6.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class HomeWork6Task2Controller : ControllerBase
    {

        private List<int> filtredScores = new List<int>();

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

                if (item >= 60)
                {

                    filtredScores.Add(item);

                }

            }

            return Ok(filtredScores);

        }

    }
}
