using System.Data.Entity;

namespace SomeDataLibrary.Model
{
    public class DataContext:DbContext
    {
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public DataContext():base("DbConnect")
        {
            
        }

    }
}
