using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Some.Controllers
{
    public class SomeBaseController:IController
    {
        public void Execute(RequestContext requestContext)
        {
            string controller = (string) requestContext.RouteData.Values["controller"];
            string action = (string) requestContext.RouteData.Values["action"];
        }
    }
}