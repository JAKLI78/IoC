using System.Collections.Generic;
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


        public void AddCompany(int companyID,int userID)
        {

            var userToUpdate = FindById(userID);
            userToUpdate.Company = companyID;
            Update(userToUpdate);
        }

        public int GetIdByName(string name)
        {
            return Get(u => u.Name == name).First().Id;
        }
    }
}