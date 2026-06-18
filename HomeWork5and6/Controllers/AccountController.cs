using HomeWork5and6.services;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork5and6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _account;

        public AccountController(AccountService account)
        {
            _account = account;
        }

        [HttpGet("balance")]
        public ActionResult GetBalance()
        {
            return Ok(new { Balance = _account.Balance });
        }

        [HttpPost("balance")]
        public ActionResult Deposit([FromBody] decimal deposit)
        {
            _account.AddFunds(deposit);

            return Ok(new { Message = "Депозит успешно внесен", NewBalance = _account.Balance });

        }
        [HttpDelete("balance")]

        public ActionResult Withdraw([FromBody] decimal amount)
        {
            bool isSuccess = _account.Withdraw(amount);

            if (!isSuccess)
            {
                return BadRequest(new { Message = "Не удалось выполнить операцию. Недостаточно средств или сумма указана неверно." });
            }

            return Ok(new { Message = "Средства успешно сняты", NewBalance = _account.Balance });
        }
    }
}
