using System.Data.Entity;
using System.Linq;
using SomeDataLibrary.Interface;
using SomeDataLibrary.Model;

namespace SomeDataLibrary.Class
{
    public class CompanyRepository:BaseRepository<Company>,ICompanyRepository
    {
        public CompanyRepository(DbContext context) : base(context)
        {
        }

        public int GetCompanyIdByName(string companyName)
        {
            return Get(c => c.CompanyName == companyName).First().Id;
        }
    }
}
