using System;
using System.Data.Entity;
using System.Linq;
using Castle.Core.Logging;
using SomeDataLibrary.Interface;
using SomeDataLibrary.Model;

namespace SomeDataLibrary.DataRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ILogger _logger;

        public UserRepository(DbContext context, ILogger logger) : base(context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger),
                $"{nameof(logger)} cannot be null.");
        }

        public void AddUserToCompany(int companyID, int userID)
        {
            var userToUpdate = FindById(userID);
            if (userToUpdate == null) return;
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