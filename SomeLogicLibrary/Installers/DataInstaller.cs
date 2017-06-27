using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace SomeLogicLibrary.Installers
{
    public class DataInstaller :IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(Component.For<SomeDataLibrary.Model.DataContext>().LifestyleTransient());
            container.Register(Component
                .For<SomeDataLibrary.Interface.IUserRepository>()
                .ImplementedBy<SomeDataLibrary.Class.UserRepository>().LifestyleTransient());
            container.Register(Component
                .For<SomeDataLibrary.Interface.ICompanyRepository>()
                .ImplementedBy<SomeDataLibrary.Class.CompanyRepository>().LifestyleTransient());
            
        }
    }
}
