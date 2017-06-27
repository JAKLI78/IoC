using System;
using SomeDataLibrary.Model;

namespace SomeDataLibrary.Interface
{
    public interface ICompanyRepository: IRepository<Company>
    {
        int? GetCompanyIdByName(string companyName);
    }
}