using Microsoft.AspNetCore.Components;
using PangWeb.Services;

namespace PangWeb.Pages.Components.AdminPage.ProductComponents
{
    public partial class AdminProductComponent
    {
        [Inject]
        private ProductService _productService { get; set; }

        // Create Product dialog
        private bool createProductDialogOpen { get; set; }
        private void CloseCreateProductDialog()
        {
            createProductDialogOpen = false;
        }

        // Edit Product Dialog
        private int SelectedId { get; set; } = 0;
        private void SetSelectedId(int selectedRowId = 0)
        {
            SelectedId = selectedRowId;
        }
    }
}
