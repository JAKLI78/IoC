﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SomeDataLibrary.DataRepository;
using SomeDataLibrary.Interface;

namespace SomeLogicLibrary.Installers
{
    public class DataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                .For<IUserRepository>()
                .ImplementedBy<UserRepository>().LifestyleTransient());
            container.Register(Component
                .For<ICompanyRepository>()
                .ImplementedBy<CompanyRepository>().LifestyleTransient());
        }
    }
}