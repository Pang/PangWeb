using PangWeb.API.Data;
using PangWeb.Shared;

namespace PangWeb.API.Services
{
    public class DataSeedService
    {
        private DataContext _context;
        public DataSeedService(DataContext context)
        {
            _context = context;
            context.Database.EnsureCreated();

            CreateBlogs();
            CreateProductCategories();
            CreateProducts();

            context.SaveChanges();
        }

        #region CreateBlogs
        private void CreateBlogs()
        {
            if (_context.Blogs.Any()) return;

            var blogs = new Blog[]
            {
                new Blog { 
                    Title = "Test One", 
                    Summary = "Lorem ipsum dolor sit amet", 
                    Date = DateTimeOffset.Now, 
                    Active = true, 
                    ImgUrl = "https://picsum.photos/200" 
                },
                new Blog { 
                    Title = "Test Two", 
                    Summary = "Consectetur adipiscing elit", 
                    Date = DateTimeOffset.Now, 
                    Active = true, 
                    ImgUrl = "https://picsum.photos/200" 
                },
                new Blog { 
                    Title = "Test Three", 
                    Summary = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", 
                    Date = DateTimeOffset.Now, 
                    Active = true, 
                    ImgUrl = "https://picsum.photos/200" 
                },
                new Blog { 
                    Title = "Test Four", 
                    Summary = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris", 
                    Date = DateTimeOffset.Now, 
                    Active = true, 
                    ImgUrl = "https://picsum.photos/200" 
                },
            };

            foreach (var blog in blogs)
            {
                _context.Blogs.Add(blog);
            }
        }
        #endregion

        #region CreateProductCategories
        private void CreateProductCategories()
        {
            if (_context.ProductCategories.Any()) return;

            var categories = new ProductCategory[]
            {
                new ProductCategory
                {
                    Category = "All",
                },
                new ProductCategory
                {
                    Category = "Art",
                },
                new ProductCategory
                {
                    Category = "Clothes",
                },
                new ProductCategory
                {
                    Category = "Merch",
                },
            };

            foreach (var category in categories)
            {
                _context.ProductCategories.Add(category);
            }
        }
        #endregion

        #region CreateProducts
        private void CreateProducts()
        {
            if (_context.Products.Any()) return;

            var products = new Product[]
            {
                new Product
                {
                    Id = 1,
                    ProductCategoryId = 1,
                    Price = 20.00m,
                    Name = "Canvas Art Piece 1",
                    Description = "Such beautiful scenery",
                    ImgUrl = "https://picsum.photos/200",
                    Active = true,
                    DateAdded = DateTimeOffset.Parse("11/05/2015"),
                },
                new Product {
                    Id = 2,
                    ProductCategoryId = 3,
                    Price = 10.00m,
                    Name = "Customized Mug",
                    Description = "Fill me up!",
                    ImgUrl = "https://picsum.photos/200",
                    Active = true,
                    DateAdded = DateTimeOffset.Parse("14/03/2017"),
                },
                new Product {
                    Id = 3,
                    ProductCategoryId = 2,
                    Price = 15.00m,
                    Name = "Customized T-shirt",
                    Description = "Stand out with fresh swag!",
                    ImgUrl = "https://picsum.photos/200",
                    Active = true,
                    DateAdded = DateTimeOffset.Parse("17/01/2021"),
                },

            };

            foreach (var product in products)
            {
                _context.Products.Add(product);
            }
        }
        #endregion
    }
}
