using SomeDataLibrary.Model;

namespace SomeDataLibrary.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        void AddUserToCompany(int companyID, int userID);
        int? GetIdByName(string userName);
    }
}