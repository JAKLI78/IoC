using System.Collections.Generic;
using SomeDataLibrary.Interface;
using SomeDataLibrary.Model;
using SomeLogicLibrary.Interface;

namespace SomeLogicLibrary.Class
{
    public class TestService :ITestService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly INotificator[] _notificators;

        public TestService(INotificator[] notificators,IUserRepository userRepository,ICompanyRepository companyRepository)
        {
            _notificators = notificators;
            _userRepository = userRepository;
            _companyRepository = companyRepository;
        }

        public void SetCompanyToUser(int companyId, int userId)
        {
            
            _userRepository.AddUserToCompany(companyId,userId);
            foreach (var notificator in _notificators)
            {
                notificator.Send(
                    $"user {_userRepository.FindById(userId).Name} now working in company {_companyRepository.FindById(companyId).CompanyName}");
            }
        }

        public  IEnumerable<User> GetUsersIdAndNames()
        {            
            return _userRepository.Get();
        }

        public IEnumerable<Company> GetCompanysIdAndNames()
        {

            return _companyRepository.Get();
        }
    }        
}
