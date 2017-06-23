using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using StructureMap;

namespace SomeLogicLibrary.Class
{
    public class SomeLogicRegistry:Registry
    {
        public SomeLogicRegistry()
        {
            For<SomeDataLibrary.Interface.IUserRepository>().Use<SomeDataLibrary.Class.UserRepository>();
            For<SomeDataLibrary.Interface.ICompanyRepository>().Use<SomeDataLibrary.Class.CompanyRepository>();
            For<Interface.ITestService>().Use<TestService>();
        }
    }
}
