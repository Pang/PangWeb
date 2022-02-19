using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using PangWeb.Services;
using PangWeb.Shared;

namespace PangWeb.Pages.Components.AdminPage.ProductComponents
{
    public partial class CreateProductComponent
    {
        [Inject]
        private ProductService _productService { get; set; }

        [Parameter]
        public Product ProductForm { get; set; } = new Product();

        [Parameter]
        public bool dialogOpen { get; set; } = false;

        [Parameter]
        public EventCallback<bool> OnCreateProductDialogClose { get; set; }

        public void SaveProductToList()
        {
            if (_productService.AddNewProduct(ProductForm))
            {
                ProductForm = new Product();
                OnCreateProductDialogClose.InvokeAsync();
            }
        }
    }
}