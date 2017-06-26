using System.Collections.Generic;

namespace SomeLogicLibrary.Interface
{
    public interface ITestService
    {
        void SetCompanyToUser(int companyId, int userId);
        List<string> GetUsersIdAndNames();
        List<string> GetCompanysIdAndNames();
    }
}