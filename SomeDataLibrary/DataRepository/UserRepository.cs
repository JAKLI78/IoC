using System;
using System.Data.Entity;
using System.Linq;
using Castle.Core.Logging;
using SomeDataLibrary.Interface;
using SomeDataLibrary.Model;

namespace SomeDataLibrary.Class
{
    public class UserRepository : BaseRepository<User>,IUserRepository
    {
        private ILogger _logger;

        public UserRepository(DbContext context,ILogger logger) : base(context)
        {
            _logger = logger ?? throw new ArgumentNullException("logger");
        }

        public void AddUserToCompany(int companyID,int userID)
        {
            var userToUpdate = FindById(userID);
            userToUpdate.CompanyId = companyID;
            Update(userToUpdate);
        }

        public int? GetIdByName(string userName)
        {
            try
            {
                var result = Get(u => u.Name == userName).First().Id;
                return result;
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return null;
            }             
        }
    }
}