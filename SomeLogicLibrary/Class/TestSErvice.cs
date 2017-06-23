using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using SomeDataLibrary.Class;
using SomeDataLibrary.Interface;
using SomeDataLibrary.Model;
using SomeLogicLibrary.Interface;

namespace SomeLogicLibrary.Class
{
    public class TestService :ITestService
    {
        private  IWindsorContainer container;
        private readonly IUserRepository userRepository;
        private readonly ICompanyRepository companyRepository;
        private INotificator[] notificators;

        public TestService(IWindsorContainer container)
        {
            this.container = container;
            container.Install(FromAssembly.Named("SomeLogicLibrary"));
            var context = container.Resolve<SomeEntities>();
            userRepository = container.Resolve<IUserRepository>(new {context});
            notificators = container.ResolveAll<INotificator>();
            companyRepository = container.Resolve<ICompanyRepository>(new { context });
        }

        public void SetCompanyToUser(string company, string user)
        {
            var userId = userRepository.GetIdByName(user);
            var companyId = companyRepository.GetCompanyByName(company);
            userRepository.AddCompany(companyId,userId);
            foreach (var notificator in notificators)
            {
                notificator.Send(
                    $"user {userRepository.FindById(userId).Name} now working in company {companyRepository.FindById(companyId).Company1}");
            }
        }

        public  List<string> GetUsersIdAndNames()
        {
            List<string> resulList = new EditableList <string>();
            resulList.AddRange(userRepository.Get().Select(user =>user.Name));
            return resulList;
        }

        public List<string> GetCompanysIdAndNames()
        {
            List<string> resulList = new EditableList<string>();
            resulList.AddRange(companyRepository.Get().Select(company => company.Company1));
            return resulList;
        }
    }
        
}
