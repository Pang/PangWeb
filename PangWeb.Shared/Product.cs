namespace PangWeb.Shared
{
    public class Product
    {
        public Product() { }
        public Product(Product product, ProductCategory category)
        {
            Id = product.Id;
            ProductCategoryId = product.ProductCategoryId;
            Name = product.Name;
            Description = product.Description;
            ImgUrl = product.ImgUrl;
            active = product.active;
            DateAdded = product.DateAdded;
            ProductType = category;
        }

        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public bool active { get; set; }
        public DateTimeOffset DateAdded { get; set; }

        public ProductCategory ProductType { get; set; }
    }

    public class ProductCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }
    }
}