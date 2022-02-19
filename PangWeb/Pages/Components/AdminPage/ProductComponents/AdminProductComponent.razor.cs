using Microsoft.AspNetCore.Components;
using PangWeb.Services;

namespace PangWeb.Pages.Components.AdminPage.ProductComponents
{
    public partial class AdminProductComponent
    {
        [Inject]
        private ProductService _productService { get; set; }

        private int SelectedId { get; set; } = 0;

        protected override void OnInitialized() { }

        private void SetSelectedId(int selectedRowId = 0)
        {
            SelectedId = selectedRowId;
        }
    }
}
