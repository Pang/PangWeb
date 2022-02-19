using Microsoft.AspNetCore.Components;
using PangWeb.Services;
using PangWeb.Shared;

namespace PangWeb.Pages.Components.AdminPage.ProductComponents
{
    public partial class EditProductDialogComponent
    {
        [Parameter]
        public EventCallback<int> OnModalClose { get; set; }
        [Inject]
        private ProductService _productService { get; set; }
        private Product EditProductForm;
        private bool showDeleteDialog;
        private int _selectedId;

        [Parameter]
        public int SelectedId
        {
            get { return _selectedId; }
            set
            {
                _selectedId = value;
                if (value > 0) EditProductForm = _productService.GetProductById(value);
            }
        }

        private void SaveEdittedProduct()
        {
            if (_productService.SaveEdittedProduct(EditProductForm))
                OnModalClose.InvokeAsync();
        }
    }
}
