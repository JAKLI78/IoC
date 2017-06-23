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
            ViewBag.users = MvcApplication.Service.GetUsersIdAndNames();
            ViewBag.companys = MvcApplication.Service.GetCompanysIdAndNames();
            return View();
        }
    }
}