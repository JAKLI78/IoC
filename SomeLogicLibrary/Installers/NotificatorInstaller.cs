using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SomeLogicLibrary.Interface;

namespace SomeLogicLibrary.Installers
{
    public class NotificatorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn<INotificator>().LifestyleSingleton());
        }
    }
}
