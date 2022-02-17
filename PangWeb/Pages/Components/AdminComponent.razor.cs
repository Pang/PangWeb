using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using PangWeb.Services;
using PangWeb.Shared;

namespace PangWeb.Pages.Components
{
    public partial class AdminComponent
    {
        [Inject]
        private BlogService _blogService { get; set; }

        private int SelectedId { get; set; } = 0;

        protected override void OnInitialized() { }

        private void SetSelectedId(int selectedRowId = 0)
        {
            SelectedId = selectedRowId;
        }
    }
}
