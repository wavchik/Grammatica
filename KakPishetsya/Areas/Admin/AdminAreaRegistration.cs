using System.Web.Mvc;

namespace KakPishetsya.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin",
                "Admin/{action}",
                new { controller = "Administration", action = "Index" }
            );

            context.MapRoute(
                "AdminSections",
                "Admin/{controller}/{action}/{id}",
                new { id = UrlParameter.Optional }
            );
        }
    }
}
