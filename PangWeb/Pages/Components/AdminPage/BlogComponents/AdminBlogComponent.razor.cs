using Microsoft.AspNetCore.Components;
using PangWeb.Services;

namespace PangWeb.Pages.Components.AdminPage.BlogComponents
{
    public partial class AdminBlogComponent
    {
        [Inject]
        private BlogService _blogService { get; set; }

        // Create Blog dialog
        private bool createPostDialogOpen { get; set; }
        private void CloseCreateBlogDialog()
        {
            createPostDialogOpen = false;
        }

        // Edit Blog dialog
        private int SelectedId { get; set; } = 0;

        private void SetSelectedId(int selectedRowId = 0)
        {
            SelectedId = selectedRowId;
        }

    }
}
