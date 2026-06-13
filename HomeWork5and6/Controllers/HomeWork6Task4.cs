using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace HomeWork5and6.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class HomeWork6Task4Controller : ControllerBase
    {

        List<string> randomStrings = new List<string>
        {
            "Яблоко", "Банан", "Апельсин", "Груша", "Слива",
            "Виноград", "Киви", "Манго", "Персик", "Ананас",
            "Арбуз", "Дыня", "Лимон", "Вишня", "Черешня",
            "Абрикос", "Гранат", "Инжир", "Папайя", "Кокос"
        };


        [HttpGet("stringBuild")]
        public ActionResult TagsAnalyze()
        {

            var validTags = randomStrings.Where(tag => !string
            .IsNullOrWhiteSpace(tag))
                .ToArray();

            int validTagsCounter = validTags.Length;

            StringBuilder newString = new StringBuilder();

            newString.Append(string.Join(" ", validTags));

            string finalString = newString.ToString();

            return Ok($"Not empty - {validTagsCounter} item(s). New string: {finalString}");

        }

    }
}
