using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace HomeWork5and6.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class TagsController : ControllerBase
    {

        [HttpPost("TagsAnalyze")]
        public ActionResult TagsAnalyze(string[] tags)
        {

            var validTags = tags.Where(tag => !string
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
