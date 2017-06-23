using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel;
using Castle.Windsor;
using Castle.Windsor.Diagnostics.Extensions;
using Castle.Windsor.Installer;
using Some.Plumbing;
using SomeLogicLibrary.Interface;


namespace Some
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;
        public static ITestService Service;

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
            container = new WindsorContainer().Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            Service = container.Resolve<ITestService>(new {container});
        }

        protected void Application_End()
        {
            container.Dispose();
        }
    }
    
}
