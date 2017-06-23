using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Some.Installers
{
    public class LogicInstaller :IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<SomeLogicLibrary.Interface.ITestService>()
                .ImplementedBy<SomeLogicLibrary.Class.TestService>());
        }
    }
}