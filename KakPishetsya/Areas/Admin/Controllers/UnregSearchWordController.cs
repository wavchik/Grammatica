using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KakPishetsya.Common.Data.Repositories;
using KakPishetsya.Common.Data.Models;
using PagedList;

namespace KakPishetsya.Areas.Admin.Controllers
{
    public class UnregSearchWordController  : Controller
    {
        private const int PageSize = 20;

        private readonly BaseRepository<UnregSearchWord> _repository;

        public UnregSearchWordController(BaseRepository<UnregSearchWord> repository)
        {
            _repository = repository;
        }

        //
        // GET: /Admin/UnregSearchWords/

        public ActionResult Index(int? page)
        {
            var words = _repository.All.OrderByDescending(x => x.SearchCount).ThenBy(x => x.Name);

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
