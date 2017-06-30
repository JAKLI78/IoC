using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SomeLogicLibrary.Class;
using SomeLogicLibrary.Interface;

namespace Some.Installers
{
    public class LogicInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ITestService>()
                .ImplementedBy<TestService>().LifestylePerWebRequest());
        }
    }
}