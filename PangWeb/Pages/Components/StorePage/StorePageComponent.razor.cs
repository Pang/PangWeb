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


        protected async override void OnInitialized()
        {
            _productService.products = await _productService.GetAllProducts();
            StateHasChanged();
        }

        private async void GetListOfProductsForPage()
        {
            var categoryId = _productService.GetCategoryId(category);
            if (categoryId > 0) _productService.products = _productService.GetAllProductsByCategory(categoryId);
            else _productService.products = await _productService.GetAllProducts();
        }
    }
}
