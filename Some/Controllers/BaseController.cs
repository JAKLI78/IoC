using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Some.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public ActionResult Index()
        {
            ViewBag.users = MvcApplication._service.GetUsersIdAndNames();
            ViewBag.companys = MvcApplication._service.GetCompanysIdAndNames();

            return View();
        }
    }
}