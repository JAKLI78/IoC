using System.Web.Mvc;
using Castle.Core;
using Some.Models;
using SomeLogicLibrary.Interface;

namespace Some.Controllers
{
    public class TestController :BaseController 
    {
        
        public ITestService _testService
        {
            get;
            set;
        }

        // GET: Test
        public ActionResult Base()
        {
            ViewBag.users = _testService.GetUsersIdAndNames();
            ViewBag.companys = _testService.GetCompanysIdAndNames();

            return View();
        }
        [HttpPost]
        public void AddToUser(UserToCompanyView userToCompany)
        {

            _testService.SetCompanyToUser(userToCompany.CompanyID,userToCompany.UserID);
            
        }        
    }
}