using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SomeLogicLibrary.Interface;

namespace Some.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Base()
        {
            ViewBag.users = MvcApplication.Service.GetUsersIdAndNames();
            ViewBag.companys = MvcApplication.Service.GetCompanysIdAndNames();
            return View();
        }
        [HttpPost]
        public void AddToUser(FormCollection formCollection)
        {
            string some = formCollection["CompanyDropDown"].ToString();
            string some2 = formCollection["UserDropDown"].ToString();
            MvcApplication.Service.SetCompanyToUser(some,some2);
            
        }

        

        
    }
}