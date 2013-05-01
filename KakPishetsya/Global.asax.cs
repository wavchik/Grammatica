using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using KakPishetsya.Common.Data.Context;
using KakPishetsya.Common.Data.Repositories;
using KakPishetsya.DAL.Repositories;

namespace KakPishetsya
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterTypes(typeof(OfferWordRepository), typeof(WordRepository), typeof(UserRepository),
                                  typeof(RuleRepository), typeof(FeedbackRepository), typeof(UnregSearchWordRepository))
                   .AsClosedTypesOf(typeof(BaseRepository<>));
        }

        private static void RegisterIoC()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            RegisterDependencies(builder);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        protected void Application_Start()
        {
            RegisterIoC();

            log4net.Config.XmlConfigurator.Configure();

            Database.SetInitializer(new GrammaticaInitializer());

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static bool IsControllerActionParameterInjectionEnabled()
        {
            return false;
        }
    }
}