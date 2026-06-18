using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace HomeWork5and6.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class HomeWork6Task4Controller : ControllerBase
    {
        readonly string[] randomStrings =
        [
            "Яблоко", "Банан", "Апельсин", "Груша", "Слива",
            "Виноград", "Киви", "Манго", "Персик", "Ананас",
            "Арбуз", "Дыня", "Лимон", "Вишня", "Черешня",
            "Абрикос", "Гранат", "Инжир", "Папайя", "Кокос"
        ];


        [HttpGet("stringBuild")]
        public ActionResult TagsAnalyze()
        {

            StringBuilder newString = new StringBuilder();

            newString.AppendJoin(" ", randomStrings);

            string finalString = newString.ToString();

            return Ok($"Length - {finalString.Length} item(s). New string: {finalString}");

        }

    }
}
