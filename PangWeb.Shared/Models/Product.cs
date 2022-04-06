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
            Active = product.Active;
            Price = product.Price;
            DateAdded = product.DateAdded;
            ProductType = category;
        }

        public long Id { get; set; }
        public long ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public bool Active { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset DateAdded { get; set; }

        public ProductCategory ProductType { get; set; }
    }

    //public enum ProductCategories
    //{
    //    All,
    //    Art,
    //    Clothes,
    //    Merch
    //}
}