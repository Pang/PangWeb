using PangWeb.Shared;
using PangWeb.Shared.DTOs;

namespace PangWeb.Services
{
    public class ShoppingCartService
    {
        public ShoppingCartDto _shoppingCart { private set; get; } = new ShoppingCartDto();

        public ShoppingCartService()
        {
            //_shoppingCart = SeededData();
        }

        public void AddNewProductToCart(Product product)
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
}
