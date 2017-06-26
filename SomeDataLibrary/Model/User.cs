using System;

namespace SomeDataLibrary.Model
{
    public class User:Entity
    {
        public string Name { get; set; }
        public Nullable<int> CompanyId { get; set; }        
    }
}
