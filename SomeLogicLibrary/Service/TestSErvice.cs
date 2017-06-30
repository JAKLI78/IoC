using System;
using System.Collections.Generic;
using SomeDataLibrary.Interface;
using SomeDataLibrary.Model;
using SomeLogicLibrary.Interface;

namespace SomeLogicLibrary.Service
{
    public class TestService : ITestService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly INotificator[] _notificators;
        private readonly IUserRepository _userRepository;

        public TestService(INotificator[] notificators, IUserRepository userRepository,
            ICompanyRepository companyRepository)
        {
            _notificators = notificators ??
                            throw new ArgumentNullException(nameof(notificators),
                                $"{nameof(notificators)} cannot be null.");
            _userRepository = userRepository ??
                              throw new ArgumentNullException(nameof(userRepository),
                                  $"{nameof(userRepository)} cannot be null.");
            _companyRepository = companyRepository ??
                                 throw new ArgumentNullException(nameof(companyRepository),
                                     $"{nameof(companyRepository)} cannot be null.");
        }

        public void SetCompanyToUser(int companyId, int userId)
        {
            _userRepository.AddUserToCompany(companyId, userId);
        }

        public void Notify(int companyId, int userId)
        {
            foreach (var notificator in _notificators)
                notificator.Send(
                    $"user {_userRepository.FindById(userId).Name} now working in company {_companyRepository.FindById(companyId).CompanyName}");
        }

        public IEnumerable<User> GetUsersIdAndNames()
        {
            return _userRepository.Get();
        }

        public IEnumerable<Company> GetCompanysIdAndNames()
        {
            return _companyRepository.Get();
        }
    }
}