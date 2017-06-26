using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SomeLogicLibrary.Interface;

namespace Some.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Base()
        {
            ViewBag.users = MvcApplication._service.GetUsersIdAndNames();
            ViewBag.companys = MvcApplication._service.GetCompanysIdAndNames();

            return View();
        }
        [HttpPost]
        public void AddToUser(FormCollection formCollection)
        {
            string some = formCollection["CompanyDropDown"];
            string some2 = formCollection["UserDropDown"];
            MvcApplication._service.SetCompanyToUser(some,some2);
            
        }        
    }
}