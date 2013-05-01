using System.Web.Mvc;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;

namespace KakPishetsya.Areas.Admin.Controllers
{
    public class FeedbacksController : Controller
    {
        private readonly BaseRepository<Feedback> _repository;

        public FeedbacksController(BaseRepository<Feedback> repository)
        {
            _repository = repository;
        }

        //
        // GET: /Admin/Feedbacks/
        public ActionResult Index()
        {
            return View(_repository.All);
        }

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
    }
}