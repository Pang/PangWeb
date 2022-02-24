using Microsoft.AspNetCore.Components;
using PangWeb.Services;

namespace PangWeb.Pages.Components.AdminPage.BlogComponents
{
    public partial class TableBlogComponent
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
        private long SelectedId { get; set; } = 0;

        private void SetSelectedId(long selectedRowId = 0)
        {
            SelectedId = selectedRowId;
        }

    }
}
