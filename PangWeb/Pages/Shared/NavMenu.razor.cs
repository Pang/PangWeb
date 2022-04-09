using Microsoft.AspNetCore.Components;
using PangWeb.Services;

namespace PangWeb.Pages.Shared
{
    public partial class NavMenu
    {
        [Inject] private ProductService _productService { get; set; }
        [Inject] private UserService _userService { get; set; }
        private bool loginDialogOpen;

        private void CloseRegisterDialog()
        {
            loginDialogOpen = false;
            //StateHasChanged();
        }

        protected async override void OnInitialized()
        {
            _productService.productCategories = await _productService.GetProductCategories();
            StateHasChanged();
        }
    }
}
