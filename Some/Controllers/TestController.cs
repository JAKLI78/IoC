using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Components.DictionaryAdapter;
using Some.Models;

namespace Some.Controllers
{
    public class TestController : BaseController
    {
        public TestController(IActionInvoker actionInvoker)
        {
            if (actionInvoker == null)
                throw new ArgumentNullException(nameof(actionInvoker), $"{nameof(actionInvoker)} cannot be null.");
            ActionInvoker = actionInvoker;
        }

        // GET: Test
        public ActionResult Base()
        {
            return View(BuildModelForView());
        }

        [HttpPost]
        public ActionResult AddToUser(UserToCompanyView userToCompany)
        {
            _testService.SetCompanyToUser(userToCompany.CompanyId, userToCompany.UserId);
            _testService.Notify(userToCompany.CompanyId, userToCompany.UserId);

            return RedirectToAction("Base");
        }

        private AllView BuildModelForView()
        {
            List<UserView> userViews = new EditableList<UserView> {new UserView {Id = 0, Name = ""}};
            userViews.AddRange(_testService.GetUsersIdAndNames()
                .Select(user => new UserView {CompanyId = user.CompanyId, Id = user.Id, Name = user.Name}));

            List<CompanyView> companyViews = new EditableList<CompanyView> {new CompanyView {Id = 0, CompanyName = ""}};
            companyViews.AddRange(_testService.GetCompanysIdAndNames()
                .Select(companys => new CompanyView {CompanyName = companys.CompanyName, Id = companys.Id}));

            return new AllView {CompanyViews = companyViews, UserViews = userViews};
        }
    }
}