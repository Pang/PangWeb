using PangWeb.Shared;
using PangWeb.Shared.DTOs;

namespace PangWeb.Services
{
    public class ShoppingCartService
    {
        public ShoppingCartDto _shoppingCart { private set; get; } = new ShoppingCartDto();

        public ShoppingCartService()
        {
            _shoppingCart = SeededData();
        }

        public void AddNewProductToCart(Product product)
        {
            if (_shoppingCart.Items.Any(x => x.Product.Id == product.Id))
            {
                _shoppingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id).Quantity++;
            }
            else
            {
                var newItem = new ShoppingCartItemDto()
                {
                    Name = product.Name,
                    Quantity = 1,
                    Price = product.Price,
                    ProductId = product.Id,
                    Product = product
                };
                _shoppingCart.Items.Add(newItem);
            }
        }

        public void RemoveProductToCart(Product product)
        {
            // if quantity>1 
            if (_shoppingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id).Quantity > 1)
            {
                _shoppingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id).Quantity--;
            }
            else
            {
                var item = _shoppingCart.Items.Where(x => x.Product.Id == product.Id).FirstOrDefault();
                _shoppingCart.Items.Remove(item);
            }

        }

        private ShoppingCartDto SeededData()
        {
            var items = new List<ShoppingCartItemDto>();
            items.Add(new ShoppingCartItemDto()
            {
                Quantity = 2,
                Price = 20.00m,
                ProductId = 1,
                Product = new Product
                {
                    Id = 1,
                    ProductCategoryId = 1,
                    Name = "Canvas Art Piece 1",
                    Description = "Such beautiful scenery",
                    ImgUrl = "https://picsum.photos/400",
                    Active = true,
                    DateAdded = DateTimeOffset.Parse("11/05/2015"),
                },
            });
            ShoppingCartDto shopCart = new ShoppingCartDto() { Items = items, NoOfItems = items.Count, TotalPrice = CalculateTotalPrice(items) };
            return shopCart;
        }

        private decimal CalculateTotalPrice(List<ShoppingCartItemDto> items)
        {
            var price = 0m;
            foreach (var item in items)
            {
                price += item.Price;
            }
            return price;
        }
    }
}
