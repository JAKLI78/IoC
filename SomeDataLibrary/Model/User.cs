namespace SomeDataLibrary.Model
{
    public class User : Entity
    {
        public string Name { get; set; }
        public int? CompanyId { get; set; }

        public Company Company { get; set; }
    }
}