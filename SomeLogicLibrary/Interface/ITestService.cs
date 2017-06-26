using System.Collections.Generic;

namespace SomeLogicLibrary.Interface
{
    public interface ITestService
    {
        void SetCompanyToUser(string company, string user);
        List<string> GetUsersIdAndNames();
        List<string> GetCompanysIdAndNames();
    }
}