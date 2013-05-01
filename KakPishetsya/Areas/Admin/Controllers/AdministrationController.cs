using System.Linq;
using System.Web.Mvc;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;
using KakPishetsya.Common.Data.Utils;
using KakPishetsya.DAL.Controllers;
using KakPishetsya.Models;

namespace KakPishetsya.Areas.Admin.Controllers
{
    [Authorize]
    public class AdministrationController : PageDataController<User>
    {
        public AdministrationController(BaseRepository<User> repository)
            : base(repository)
        {
        }

        private const string CookieName = "KakPishetsya";

        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = _repository.FindBy(x => x.Login.Equals(model.UserName)).FirstOrDefault();
            var saltedHash = new SaltedHash(model.Password);

            if (user != null && SaltedHash.Verify(saltedHash.Salt, saltedHash.Hash, model.Password))
            {
                System.Web.Security.FormsAuthentication.SetAuthCookie(CookieName, true);
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Пользователя с введенными данными не существует или введенные данные неправильные.");
            return View();
        }

        public ActionResult LogOff()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Index", new { controller = "Home", area = "" });
        }
    }
}