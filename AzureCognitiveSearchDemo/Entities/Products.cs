namespace AzureCognitiveSearchDemo.Entities
{
    public class Products
    {
        public Products(string name, string description, DateTime creation)
        {
            Name = name;
            Description = description;
            Creation = creation;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Creation { get; set; }
    }
}
