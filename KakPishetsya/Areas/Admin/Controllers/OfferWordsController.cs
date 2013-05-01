using System.Web.Mvc;
using System.Linq;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;
using PagedList;

namespace KakPishetsya.Areas.Admin.Controllers
{
    public class OfferWordsController : Controller
    {
        private const int PageSize = 20;

        private readonly BaseRepository<OfferWord> _repository;

        public OfferWordsController(BaseRepository<OfferWord> repository)
        {
            _repository = repository;
        }

        //
        // GET: /Admin/OfferWords/

        public ActionResult Index(int? page)
        {
            var words = _repository.All.OrderBy(x => x.Name);

            int pageNumber = page ?? 1;
            var onePageOfWords = words.ToPagedList(pageNumber, PageSize);

            ViewBag.OnePageOfWords = onePageOfWords;
            return View();
        }

        //
        // GET: /Admin/OfferWords/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/OfferWords/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/OfferWords/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/OfferWords/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}