using System.Web.Mvc;
using log4net;

namespace KakPishetsya.Common.Data.Controllers
{
    public abstract class PageController : Controller
    {
        protected PageController()
            : base()
        {
            Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        protected ILog Logger { get; private set; }
    }
}