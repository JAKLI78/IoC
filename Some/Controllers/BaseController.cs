using System.Web.Mvc;
using SomeLogicLibrary.Interface;

namespace Some.Controllers
{
    public class BaseController : Controller
    {
        public ITestService _testService
        {
            get;
            set;
        }
    }
}