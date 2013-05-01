using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;
using KakPishetsya.DAL.Controllers;

namespace KakPishetsya.Controllers
{
    public class WordController : PageDataController<Word>
    {
        public WordController(BaseRepository<Word> repository)
            : base(repository)
        {
        }

        public ActionResult Index(string smartname)
        {
            var word = _repository.FindBy(x => x.SmartName == smartname).FirstOrDefault();

            if (word == null)
            {
                throw new HttpException(404, "Запрашиваемая страница не существует");
            }

            word.Keywords = word.Name + ", " + word.InvalidDescription + ConfigurationManager.AppSettings["seoKeywordsPostfix"];

            return View(word);
        }

        private string GetExactWordResult(string chars, string valid, IEnumerable<string> invalid)
        {
            string lowerChars = chars.ToLower();

            if (valid.ToLower().StartsWith(chars))
            {
                return valid;
            }

            var invalidResult = invalid.Where(x => x.ToLower().StartsWith(lowerChars));
            return invalidResult.FirstOrDefault() ?? valid;
        }

        public JsonResult Find(string name)
        {
            Response.ContentType = "application/json";

            name = name.ToLower();

            var findWords =
                SearchFunctions.GetSearchByWordQuery(name).ToList()
                .Select(x => new
                {
                    Name = GetExactWordResult(name, x.Name, (x.InvalidDescription ?? string.Empty).Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries)),
                    x.SmartName
                });

            var result = Json((new { words = findWords }), JsonRequestBehavior.AllowGet);
            return result;
        }
    }
}