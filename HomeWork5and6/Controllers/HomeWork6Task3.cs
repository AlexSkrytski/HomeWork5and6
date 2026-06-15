using HomeWork5and6.Domains;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork5and6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeWork6Task3Controller : ControllerBase
    {

        // Пример статического метода деления
        public static bool TryDivide(double dividend, double divisor, out double result)
        {
            if (divisor == 0)
            {
                result = 0;
                return false; // Деление на ноль невозможно
            }

            result = dividend / divisor;
            return true;
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
            bool isSuccess = TryDivide(request.Dividend, request.Divisor, out double calculationResult);

            if (isSuccess)
            {
                return Ok(new { Success = true, Result = calculationResult });
            }

            return BadRequest(new { Success = false, Message = "Division by zero." });
        }
    }
}
