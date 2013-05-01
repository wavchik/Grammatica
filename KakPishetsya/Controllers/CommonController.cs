using System.Web.Mvc;

namespace KakPishetsya.Controllers
{
    public class CommonController : Controller
    {
        public ActionResult Search()
        {
            return PartialView();
        }
    }
}