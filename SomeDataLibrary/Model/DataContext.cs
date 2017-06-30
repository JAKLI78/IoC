using System.Data.Entity;

namespace SomeDataLibrary.Model
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DbConnect")
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}