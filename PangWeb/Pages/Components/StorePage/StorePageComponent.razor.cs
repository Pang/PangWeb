using Microsoft.AspNetCore.Components;
using PangWeb.Services;
using PangWeb.Shared;

namespace PangWeb.Pages.Components.StorePage
{
    public partial class StorePageComponent
    {
        [Parameter]
        public string? category
        {
            get
            {
                return _category;
            }
            set
            {
                if (value != null) _category = value;
                GetListOfProductsForPage();
            }
        }
        private string? _category;

        [Inject]
        private ProductService _productService { get; set; }
        [Inject]
        private UserService _userService { get; set; }
        [Inject]
        private ShoppingCartService _shoppingCartService { get; set; }

        private List<Product> _productsToShow { get; set; } = new List<Product>();

        protected async override void OnInitialized()
        {
            _productService.products = await _productService.GetAllProducts();
            StateHasChanged();
        }

        private async void GetListOfProductsForPage()
        {
            var categoryId = _productService.GetCategoryId(category);

            if (categoryId == 1)
                _productsToShow = _productService.products;
            else
                _productsToShow = _productService.products.Where(x => x.ProductCategoryId == categoryId).ToList();

            StateHasChanged();
        }
    }
}
