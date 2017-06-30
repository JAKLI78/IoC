using System;
using System.Data.Entity;
using System.Linq;
using Castle.Core.Logging;
using SomeDataLibrary.Interface;
using SomeDataLibrary.Model;

namespace SomeDataLibrary.DataRepository
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly ILogger _logger;

        public CompanyRepository(DbContext context, ILogger logger) : base(context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger),
                $"{nameof(logger)} cannot be null.");
        }

        public int? GetCompanyIdByName(string companyName)
        {
            try
            {
                var result = Get(c => c.CompanyName == companyName).First().Id;
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