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
        private  IWindsorContainer _container;
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly INotificator[] _notificators;

        public TestService(IWindsorContainer container)
        {
            this._container = container;
            container.Install(FromAssembly.Named("SomeLogicLibrary"));
            var context = container.Resolve<DataContext>();
            _userRepository = container.Resolve<IUserRepository>(new {context});
            _notificators = container.ResolveAll<INotificator>();
            _companyRepository = container.Resolve<ICompanyRepository>(new { context });
        }

        public void SetCompanyToUser(string companyName, string userName)
        {
            var userId = _userRepository.GetIdByName(userName);
            var companyId = _companyRepository.GetCompanyIdByName(companyName);
            _userRepository.AddUserToCompany(companyId,userId);
            foreach (var notificator in _notificators)
            {
                notificator.Send(
                    $"user {_userRepository.FindById(userId).Name} now working in company {_companyRepository.FindById(companyId).CompanyName}");
            }
        }

        public  List<string> GetUsersIdAndNames()
        {
            List<string> resulList = new EditableList <string>();
            resulList.AddRange(_userRepository.Get().Select(user =>user.Name));
            return resulList;
        }

        public List<string> GetCompanysIdAndNames()
        {
            List<string> resulList = new EditableList<string>();
            resulList.AddRange(_companyRepository.Get().Select(company => company.CompanyName));
            return resulList;
        }
    }        
}
