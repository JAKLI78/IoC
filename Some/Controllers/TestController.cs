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
            return View("Base", BuildModelForView());
        }

        private AllView BuildModelForView()
        {
            List<UserView> userViews = new EditableList<UserView>();
            userViews.AddRange(_testService.GetUsersIdAndNames()
                .Select(user => new UserView {CompanyId = user.CompanyId, Id = user.Id, Name = user.Name}));

            List<CompanyView> companyViews = new EditableList<CompanyView>();
            companyViews.AddRange(_testService.GetCompanysIdAndNames()
                .Select(companys => new CompanyView {CompanyName = companys.CompanyName, Id = companys.Id}));

            return new AllView {CompanyViews = companyViews, UserViews = userViews};
        }
    }
}