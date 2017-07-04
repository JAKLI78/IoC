using SomeDataLibrary.Model;

namespace SomeDataLibrary.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        void AddUserToCompany(int companyId, int userId);
    }
}