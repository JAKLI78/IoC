using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Components.DictionaryAdapter;
using Some.Models;

namespace Some.Controllers
{
    public class TestController :BaseController 
    {

        public TestController(IActionInvoker actionInvoker)
        {
            ActionInvoker = actionInvoker;
        }

        // GET: Test
        public ActionResult Base()
        {
            List<UserView> userViews = new EditableList<UserView>();
            userViews.AddRange(_testService.GetUsersIdAndNames().Select(user => new UserView() {CompanyId = user.CompanyId, Id = user.Id, Name = user.Name}));

            List<CompanyView> companyViews = new EditableList<CompanyView>();
            companyViews.AddRange(_testService.GetCompanysIdAndNames().Select(companys => new CompanyView() {CompanyName = companys.CompanyName, Id = companys.Id}));

            var model = new AllView(){CompanyViews =  companyViews,UserViews = userViews};
            return View(model);
        }
        [HttpPost]
        public void AddToUser(AllView userToCompany,FormCollection formCollection)
        {
            var companyId = int.Parse(formCollection["CompanyDropDown"]);
            var userId = int.Parse(formCollection["UserDropDown"]);
            _testService.SetCompanyToUser(companyId,userId);
            _testService.Notify(companyId,userId);
        }        
    }
}