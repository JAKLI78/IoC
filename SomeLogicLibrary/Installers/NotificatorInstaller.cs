using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SomeLogicLibrary.Class;
using SomeLogicLibrary.Interface;

namespace SomeLogicLibrary.Installers
{
    public class NotificatorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<INotificator>().ImplementedBy<EmailNotificator>().LifestylePerWebRequest());
            container.Register(Component.For<INotificator>().ImplementedBy<SmsNotificator>().LifestylePerWebRequest());            
        }
    }
}
