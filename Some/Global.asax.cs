using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Diagnostics.Extensions;
using Castle.Windsor.Installer;
using Some.Controllers;
using Some.Plumbing;
using SomeDataLibrary.Interface;
using SomeDataLibrary.Model;
using SomeLogicLibrary.Interface;


namespace Some
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BootstrapContanier();
        }

        private static void BootstrapContanier()
        {
            _container = new WindsorContainer();
            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel));
            _container.Register(Component.For<System.Data.Entity.DbContext>().LifestyleTransient());
            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            _container.Install(FromAssembly.Named("SomeLogicLibrary"));
            _container.Install(FromAssembly.This());


            var some = "mkm";



        }

        protected void Application_End()
        {
            _container.Dispose();
        }
    }
    
}
