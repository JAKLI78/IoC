using SomeDataLibrary.Model;

namespace SomeDataLibrary.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        void AddCompany(int companyID,int userID);
        int GetIdByName(string name);
    }
}