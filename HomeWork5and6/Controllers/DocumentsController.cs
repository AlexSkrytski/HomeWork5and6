using HomeWork5and6.Domains;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork5and6.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateDocument([FromBody] Document document)
        {
            // Правяраем, ці з'яўляецца дакумент менавіта інвойсам
            if (document is InvoiceDocument invoice)
            {
                // Тут логіка захавання інвойсу ў базу даных
                var result = $"Invoice created successfully. Amount: {invoice.Amount} {invoice.Currency}";

                return CreatedAtAction(nameof(CreateDocument), new { id = invoice.Id }, result);
            }

            // Калі прыйшоў кантракт або іншы тып дакумента
            return BadRequest("This endpoint only accepts Invoice documents.");
        }
    }
}


//{
//  "type": "invoice",
//  "id": 101,
//  "title": "Штомесячны рахунак за паслугі",    JSON example.
//  "amount": 1500.50,
//  "currency": "BYN"
//}