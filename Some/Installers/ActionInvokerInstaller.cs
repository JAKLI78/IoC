using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Some.Controllers;

namespace Some.Installers
{
    public class ActionInvokerInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<System.Web.Mvc.IActionInvoker>().ImplementedBy<SomeActionInvoker>()
                .LifestylePerWebRequest());
        }
    }
}