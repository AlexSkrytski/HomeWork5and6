using HomeWork5and6.Domains;
using HomeWork5and6.services;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork5and6.Controllers
{
    [ApiController]
    [Route("api/discounts")]
    public class DiscountController : ControllerBase
    {
        private readonly DiscountService _discountService;

        public DiscountController(DiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost("calculate")]
        public ActionResult<OrderContext> ApplyDiscounts([FromBody] OrderContext order)
        {
            if (order == null) return BadRequest("Неверный формат заказа");

            _discountService.CalculateFinalPrice(order);

            return Ok(order);
        }
    }
}
