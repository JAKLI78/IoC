using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return Get(c => c.Company1 == companyName).First().Id;
        }
    }
}
