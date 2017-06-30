using System.Data.Entity;
using SomeDataLibrary.Interface;
using SomeDataLibrary.Model;

namespace SomeDataLibrary.DataRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public void AddUserToCompany(int companyID, int userID)
        {
            var userToUpdate = FindById(userID);
            if (userToUpdate == null) return;
            userToUpdate.CompanyId = companyID;
            Update(userToUpdate);
        }
    }
}