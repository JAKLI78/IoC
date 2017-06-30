using System.Collections.Generic;

namespace SomeDataLibrary.Model
{
    public class Company : Entity
    {
        public Company()
        {
            Users = new List<User>();
        }

        public virtual string CompanyName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}