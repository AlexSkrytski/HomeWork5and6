using HomeWork5and6.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork5and6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServiceable _account;

        public AccountController(IAccountServiceable account)
        {
            _account = account;
        }

        [HttpGet("balance")]
        public ActionResult<decimal> GetBalance()
        {
            return Ok($"Балланс : {_account.Balance} руб.");
        }

        [HttpPost("balance")]
        public ActionResult Deposit([FromBody] decimal deposit)
        {
            _account.AddFunds(deposit);

            return Ok(new { Message = "Депозит успешно внесен.", NewBalance = _account.Balance });

        }
        [HttpDelete("balance")]

        public ActionResult Withdraw([FromBody] decimal amount)
        {
            bool isSuccess = _account.Withdraw(amount);

            if (!isSuccess)
            {
                return BadRequest(new { Message = "Не удалось выполнить операцию. Недостаточно средств или сумма указана неверно." });
            }

            return Ok(new { Message = "Средства успешно сняты.", NewBalance = _account.Balance });
        }
    }
}
