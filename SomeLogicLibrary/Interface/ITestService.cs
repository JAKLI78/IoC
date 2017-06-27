using System.Collections.Generic;
using SomeDataLibrary.Model;

namespace SomeLogicLibrary.Interface
{
    public interface ITestService
    {
        void SetCompanyToUser(int companyId, int userId);
        IEnumerable<User> GetUsersIdAndNames();
        IEnumerable<Company> GetCompanysIdAndNames();
        void Notify(int companyId, int userId);
    }
}