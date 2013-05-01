using System.Web.Mvc;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;

namespace KakPishetsya.Areas.Admin.Controllers
{
    public class RulesController : Controller
    {
        private readonly BaseRepository<Rule> _repository;

        public RulesController(BaseRepository<Rule> repository)
        {
            _repository = repository;
        }

        //
        // GET: /Admin/Rules/

        public ActionResult Index()
        {
            return View(_repository.All);
        }

        //
        // GET: /Admin/Rules/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Rules/Create
        [HttpPost]
        public ActionResult Create(Rule rule)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _repository.InsertOrUpdate(rule);
            _repository.Save();
            return RedirectToAction("Index");
        }

        // GET: /Admin/Rules/Edit/{id}
        public ActionResult Edit(int id)
        {
            return View(_repository.Find(id));
        }

        // POST: /Admin/Rules/Edit/{id}
        [HttpPost]
        public ActionResult Edit(Rule rule)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _repository.InsertOrUpdate(rule);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}