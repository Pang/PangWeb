using Microsoft.AspNetCore.Components;
using PangWeb.Services;
using PangWeb.Shared;

namespace PangWeb.Pages.Components.AdminPage.BlogComponents
{
    public partial class TableBlogComponent
    {
        [Inject]
        private BlogService _blogService { get; set; }
        private List<Blog> AllBlogs { get; set; }
        private bool createPostDialogOpen { get; set; }
        private long SelectedId { get; set; } = 0;

        protected async override void OnInitialized()
        {
            AllBlogs = await _blogService.GetAllBlogs();
            StateHasChanged();
        }

        private void CloseCreateBlogDialog()
        {
            createPostDialogOpen = false;
        }

        private void SetSelectedId(long selectedRowId = 0)
        {
            SelectedId = selectedRowId;
        }

    }
}
