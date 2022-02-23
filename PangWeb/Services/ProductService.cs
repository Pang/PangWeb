using PangWeb.Shared;

namespace PangWeb.Services
{
    public class ProductService
    {
        private List<Product> _products;
        private List<ProductCategory> productCategories;
        private int idTracker;

        public ProductService()
        {
            _products = SeededData();
            productCategories = SeededProductTypesData();
            idTracker = GetAllProducts().Count();
        }

        public List<ProductCategory> getAllCategories()
        {
            return productCategories;
        }

        /* Get a product by its ID */
        public Product GetProductById(int id)
        {
            return _products.Where(x => x.Id == id).FirstOrDefault();
        }

        /* Get List of all _products */
        public List<Product> GetAllProducts()
        {
            return _products.OrderByDescending(x => x.DateAdded)
                .Where(x => x.active)
                .Join(
                    productCategories, 
                    p => p.ProductCategoryId, 
                    pc => pc.Id,
                    (product, category) => new Product(product, category)
                 )
                .ToList();
        }

        /* Get List of all products by category */
        public List<Product> GetAllProductsByCategory(int categoryId)
        {
            return _products.OrderByDescending(x => x.DateAdded)
                .Where(x => x.active && (x.ProductCategoryId == categoryId || categoryId == productCategories.First(x => x.Category == "All").Id))
                .Join(
                    productCategories,
                    p => p.ProductCategoryId,
                    pc => pc.Id,
                    (product, category) => new Product(product, category)
                 )
                .ToList();
        }

        /* Get List of all products */
        public List<Product> GetAllProductsAdmin()
        {
            // todo: check admin
            return _products.OrderByDescending(x => x.DateAdded).ToList();
        }

        /* Add a new products to the list */
        public bool AddNewProduct(Product productForm)
        {
            if (productForm.Name != null && productForm.Description != null)
            {
                productForm.DateAdded = DateTimeOffset.Now;
                productForm.Id = ++idTracker;
                _products.Add(productForm);
                return true;
            }
            return false;
        }

        /* Save editted product from list */
        public bool SaveEdittedProduct(Product productForm)
        {
            // todo: check admin
            if (productForm != null)
            {
                var productIndex = _products.FindIndex(x => x.Id == productForm.Id);
                _products[productIndex] = productForm;
                return true;
            }
            return false;
        }

        /* Disable _products from list */
        public void DeleteProduct(Product productForm)
        {
            // todo: check admin
            if (productForm != null)
            {
                var productIndex = _products.FindIndex(x => x.Id == productForm.Id);
                _products[productIndex].active = false;
            }
        }

        /* Reactivate _products from list */
        public void ReactivateProduct(Product productForm)
        {
            // todo: check admin
            if (productForm != null)
            {
                var productIndex = _products.FindIndex(x => x.Id == productForm.Id);
                _products[productIndex].active = true;
            }
        }

        private List<Product> SeededData()
        {
            Random rand = new Random();
            return new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    ProductCategoryId = 1,
                    Name = "Canvas Art Piece 1",
                    Description = "Such beautiful scenery",
                    ImgUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + rand.Next(1,898) + ".png",
                    active = true,
                    DateAdded = DateTimeOffset.Parse("11/05/2015"),
                },
                new Product {
                    Id = 2,
                    ProductCategoryId = 3,
                    Name = "Customized Mug",
                    Description = "Fill me up!",
                    ImgUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + rand.Next(1,898) + ".png",
                    active = true,
                    DateAdded = DateTimeOffset.Parse("14/03/2017"),
                },
                new Product {
                    Id = 3,
                    ProductCategoryId = 2,
                    Name = "Customized T-shirt",
                    Description = "Stand out with fresh swag!",
                    ImgUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + rand.Next(1,898) + ".png",
                    active = true,
                    DateAdded = DateTimeOffset.Parse("17/01/2021"),
                },
            };
        }

        public int GetCategoryId(string category)
        {
            return productCategories.Where(x => x.Category == category).FirstOrDefault().Id;
        }

        private List<ProductCategory> SeededProductTypesData()
        {
            return new List<ProductCategory>()
            {
                new ProductCategory
                {
                    Id = 0,
                    Category = "All",
                },
                new ProductCategory
                {
                    Id = 1,
                    Category = "Art",
                },
                new ProductCategory
                {
                    Id = 2,
                    Category = "Clothes",
                },
                new ProductCategory
                {
                    Id = 3,
                    Category = "Merch",
                },
            };
        }
    }
}
