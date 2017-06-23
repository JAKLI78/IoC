using SomeDataLibrary.Model;

namespace SomeDataLibrary.Interface
{
    public interface ICompanyRepository: IRepository<Company>
    {
        int GetCompanyByName(string name);
    }
}