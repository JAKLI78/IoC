using System;
using System.Linq;
using System.Web.Mvc;
using Castle.Core;
using Castle.Core.Internal;
using Castle.MicroKernel;
using Castle.Windsor;
using Some.Controllers;
using Some.Installers;
using Xunit;

namespace TestLibrary
{
    public class ControllersInstallerTests
    {
        private IWindsorContainer contanierWithControllers;

        public ControllersInstallerTests()
        {
            contanierWithControllers = new WindsorContainer()
                .Install(new ControllerInstaller());
        }

        [Fact]
        public void All_controllers_implement_IController()
        {
            var allHandlers = GetAllHandlers(contanierWithControllers);
            var controllerHandlers = GetHandlersFor(typeof(IController), contanierWithControllers);

            Assert.NotEmpty(allHandlers);
            Assert.Equal(allHandlers, controllerHandlers);
        }

        private IHandler[] GetAllHandlers(IWindsorContainer container)
        {
            return GetHandlersFor(typeof(object), container);
        }

        private IHandler[] GetHandlersFor(Type type, IWindsorContainer container)
        {
            return container.Kernel.GetAssignableHandlers(type);
        }

        [Fact]
        public void All_controllers_are_registred()
        {
            var allControllers = GetPublicClassesForApplicationAssembly(c => c.Is<IController>());
            var registeredControllers = GetImplementationTypesFor(typeof(IController), contanierWithControllers);
            Assert.Equal(allControllers, registeredControllers);
        }

        private Type[] GetImplementationTypesFor(Type type, IWindsorContainer container)
        {
            return GetHandlersFor(type, container).Select(h => h.ComponentModel.Implementation).OrderBy(t => t.Name)
                .ToArray();
        }

        private Type[] GetPublicClassesForApplicationAssembly(Predicate<Type> where)
        {
            return typeof(IController).Assembly.GetExportedTypes()
                .Where(t => t.IsClass)
                .Where(t => t.IsAbstract == false)
                .Where(where.Invoke)
                .OrderBy(t => t.Name)
                .ToArray();
        }

        [Fact]
        public void All_and_only_controllers_have_Controllers_suffix()
        {
            var allControllers = GetPublicClassesForApplicationAssembly(c => c.Name.EndsWith("Controller"));
            var registredControllers = GetImplementationTypesFor(typeof(IController), contanierWithControllers);
            Assert.Equal(allControllers, registredControllers);
        }

        [Fact]
        public void All_and_only_controllers_live_in_Controllers_namespace()
        {
            var allControllers = GetPublicClassesForApplicationAssembly(c => c.Namespace.Contains("Controllers"));
            var registredControllers = GetImplementationTypesFor(typeof(IController), contanierWithControllers);
            Assert.Equal(allControllers, registredControllers);
        }

        [Fact]
        public void All_controllers_are_transient()
        {
            var nonTransientControllers = GetHandlersFor(typeof(IController), contanierWithControllers)
                .Where(c => c.ComponentModel.LifestyleType != LifestyleType.Transient)
                .ToArray();
            Assert.Empty(nonTransientControllers);
        }

        [Fact]
        public void All_controllers_expose_themselves_as_service()
        {
            var controllerWithWrongName = GetHandlersFor(typeof(IController), contanierWithControllers)
                .Where(c => c.ComponentModel.Services.Single() != c.ComponentModel.Implementation)
                .ToArray();
            Assert.Empty(controllerWithWrongName);
        }
    }
}
