using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace SomeLogicLibrary.Installers
{
    public class DataInstaller :IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                .For<SomeDataLibrary.Interface.IUserRepository>()
                .ImplementedBy<SomeDataLibrary.Class.UserRepository>());
            container.Register(Component
                .For<SomeDataLibrary.Interface.ICompanyRepository>()
                .ImplementedBy<SomeDataLibrary.Class.CompanyRepository>());
            container.Register(Component.For<SomeDataLibrary.Model.DataContext>());
        }
    }
}
