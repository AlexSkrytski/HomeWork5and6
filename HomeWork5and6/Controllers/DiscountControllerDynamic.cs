using HomeWork5and6.DTO;
using HomeWork5and6.services;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork5and6.Controllers
{
    [ApiController]
    [Route("api/discounts")]
    public class DiscountControllerDynamic : ControllerBase
    {
        private readonly DynamicDiscountService _discountService;

        public DiscountControllerDynamic(DynamicDiscountService discountService) //DI
        {
            _discountService = discountService; 
        }

        [HttpPost("calculate-dynamic")]
        public ActionResult<OrderResponse> CalculateDynamic([FromBody] OrderRequest request)
        {
            if (request == null || request.TotalAmount <= 0)
                return BadRequest("Неверные данные запроса");

            var result = _discountService.Calculate(request);
            return Ok(result);
        }
    }
}


//{
//    "totalAmount": 1000.00,
//    "discountRules":
//  [
//    { "type": "percentage", "value": 10.0 },    JSON example
//    { "type": "fixed", "value": 50.0 }, 
//    { "type": "percentage", "value": 10.0 }
//  ]
//}