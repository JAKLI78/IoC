using System.Web.Mvc;
using System.Web.Routing;

namespace Some
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new {favicon = @"(.*/)?favicon.ico(/.*)?"});

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Test", action = "Base", id = UrlParameter.Optional}
            );
        }
    }
}