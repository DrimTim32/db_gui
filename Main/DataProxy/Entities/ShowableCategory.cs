namespace DataProxy.Entities
{
    using DatabaseConnector;

    public class ShowableCategory
    {
        public ShowableCategory(Category cat)
        {
            Slug = cat.slug;
            Name = cat.category_name;
            Overriding = cat.Category1 != null ? cat.Category1.category_name : "";
        }
        public ShowableCategory() { }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Overriding { get; set; }
    }
}
