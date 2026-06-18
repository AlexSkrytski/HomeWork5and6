using HomeWork5and6.Domains;
using HomeWork5and6.services;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork5and6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeWork6Task3Controller : ControllerBase
    {
        private readonly DevideService _devideService;
        public HomeWork6Task3Controller(DevideService devideService)
        {
            _devideService = devideService;
        }

        // HTTP-эндпоинт контроллера
        [HttpPost("divide")]
        public IActionResult GetDivisionResult([FromBody] DivisionRequest request)
        {
            // Валидация входных данных (если модель пустая)
            if (request == null)
            {
                return BadRequest(new { Message = "Invalid JSON data." });
            }

            // Вызываем статический метод, используя свойства из JSON
            bool isSuccess = _devideService.TryDivide(request.Dividend, request.Divisor, out double calculationResult);

            if (isSuccess)
            {
                return Ok(new { Success = true, Result = calculationResult });
            }

            return BadRequest(new { Success = false, Message = "Division by zero." });
        }
    }
}
