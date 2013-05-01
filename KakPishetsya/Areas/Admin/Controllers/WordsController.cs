using System.Linq;
using System.Web.Mvc;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;
using PagedList;

namespace KakPishetsya.Areas.Admin.Controllers
{
    public class WordsController : Controller
    {
        private const int PageSize = 20;

        private readonly BaseRepository<Word> _repository;
        private readonly BaseRepository<Rule> _ruleRepository;

        public WordsController(BaseRepository<Word> repository, BaseRepository<Rule> ruleRepository)
        {
            _repository = repository;
            _ruleRepository = ruleRepository;
        }

        //
        // GET: /Admin/Words/
        public object Index(int? page)
        {
            var words = _repository.AllIncluding(x => x.Rule).OrderBy(x => x.Name);

            int pageNumber = page ?? 1;
            var onePageOfWords = words.ToPagedList(pageNumber, PageSize);

            ViewBag.OnePageOfWords = onePageOfWords;
            return View();
        }

        //
        // GET: /Admin/Word/Create

        public ActionResult Create()
        {
            ViewBag.Rules = _ruleRepository.All;

            if (!string.IsNullOrEmpty(Request.Params["offerName"]))
            {
                return View(new Word() { Name = Request.Params["offerName"] });
            }

            return View();
        }

        //
        // POST: /Admin/Word/Create

        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult Create(Word entity)
        {
            ViewBag.Rules = _ruleRepository.All;

            if (!ModelState.IsValid)
            {
                return View();
            }

            _repository.InsertOrUpdate(entity);
            _repository.Save();
            return RedirectToAction("Index");
        }

        // GET: /Admin/Rules/Edit/{id}
        public ActionResult Edit(int id)
        {
            var rules = _ruleRepository.All.ToList();
            ViewBag.Rules = rules;

            return View(_repository.Find(id));
        }

        // POST: /Admin/Rules/Edit/{id}
        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult Edit(Word entity)
        {
            ViewBag.Rules = _ruleRepository.All;

            if (!ModelState.IsValid)
            {
                return View();
            }

            _repository.InsertOrUpdate(entity);
            _repository.Save();
            return RedirectToAction("Index");
        }

        //
        // POST: /Admin/Word/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        [HttpPost]
        //[ValidateInput(false)]
        public JsonResult IsWordExists(string name)
        {
            int count = _repository.All.Count(x => x.Name == name);
            return Json(count == 0);
        }

        [HttpPost]
        //[ValidateInput(false)]
        public JsonResult IsSmartWordExists(string smartName)
        {
            int count = _repository.All.Count(x => x.SmartName == smartName);
            return Json(count == 0);
        }
    }
}