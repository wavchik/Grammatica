using System.Web.Mvc;
using System.Web.Routing;

namespace KakPishetsya
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("elmah.axd");

            routes.MapRoute(
                name: "OfferWord",
                url: "OfferWord",
                defaults: new { controller = "OfferWord", action = "Offer", name = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Feedback",
                url: "Feedback/Create",
                defaults: new { controller = "Feedback", action = "Create" }
            );

            routes.MapRoute(
                name: "Sitemap",
                url: "sitemap.xml",
                defaults: new { controller = "SiteMap", action = "Index" });

            routes.MapRoute(
                "Robots.txt",
                "robots.txt",
                new { controller = "Home", action = "Robots" });

            routes.MapRoute(
                name: "Word",
                url: "{smartname}",
                defaults: new { controller = "Word", action = "Index" }
            );

            routes.MapRoute(
                name: "FindWord",
                url: "Words/Find/{name}",
                defaults: new { controller = "Word", action = "Find", name = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Search",
                url: "Search/{name}",
                defaults: new { controller = "Home", action = "Search", name = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}