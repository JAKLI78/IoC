using System.Data.Entity;
using System.Linq;
using SomeDataLibrary.Interface;
using SomeDataLibrary.Model;

namespace SomeDataLibrary.Class
{
    public class UserRepository : BaseRepository<User>,IUserRepository
    {

        public UserRepository(DbContext context) : base(context)
        {
               
        }

        public void AddUserToCompany(int companyID,int userID)
        {
            var userToUpdate = FindById(userID);
            userToUpdate.CompanyId = companyID;
            Update(userToUpdate);
        }

        public int GetIdByName(string userName)
        {
            return Get(u => u.Name == userName).First().Id;
        }
    }
}