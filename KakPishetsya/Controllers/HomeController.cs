using System.Linq;
using System.Web.Mvc;
using KakPishetsya.Common.Data.Controllers;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;
using PagedList;

namespace KakPishetsya.Controllers
{
    public class HomeController : PageController
    {
        private const int PageSize = 10;

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ViewResult Words(int? page)
        {
            var repository = DependencyResolver.Current.GetService<BaseRepository<Word>>();

            var words = repository.All.OrderBy(x => x.Name);

            int pageNumber = page ?? 1;
            var onePageOfWords = words.ToPagedList(pageNumber, PageSize);

            ViewBag.OnePageOfWords = onePageOfWords;
            return View();
        }

        public ActionResult Search(string name, int? page)
        {
            ViewData["SearchName"] = name;

            name = name.ToLower();

            var findWords = SearchFunctions.GetSearchByWordQuery(name).OrderBy(x => x.Name);

            int pageNumber = page ?? 1;
            var onePageOfWords = findWords.ToPagedList(pageNumber, PageSize);

            if (!findWords.Any())
            {
                LogUnregSearchWord(name);
            }
            else if (findWords.Count() == 1)
            {
                return RedirectToAction("Index", "Word", new { smartname = findWords.First().SmartName });
            }

            ViewBag.OnePageOfWords = onePageOfWords;
            return View();
        }

        private void LogUnregSearchWord(string name)
        {
            var rep = DependencyResolver.Current.GetService<BaseRepository<UnregSearchWord>>();
            var unregWord = rep.FindBy(x => x.Name == name).FirstOrDefault();
            if (unregWord == null)
            {
                unregWord = new UnregSearchWord()
                    {
                        Name = name,
                        SearchCount = 1
                    };
            }
            else
            {
                unregWord.SearchCount++;
            }

            rep.InsertOrUpdate(unregWord);
            rep.Save();
        }

        public ActionResult SiteMap()
        {
            return View();
        }

        public ActionResult Robots()
        {
            Response.ContentType = "text/plain";
            return View();
        }
    }
}