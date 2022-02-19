using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using PangWeb.Services;
using PangWeb.Shared;

namespace PangWeb.Pages.Components.AdminPage.BlogComponents
{
    public partial class CreateBlogComponent
    {
        [Inject]
        private BlogService _blogService { get; set; }

        [Parameter]
        public Blog BlogForm { get; set; } = new Blog();

        [Parameter]
        public bool dialogOpen { get; set; } = false;

        [Parameter]
        public EventCallback<bool> OnCreatePostDialogClose { get; set; }

        public void SavePostToList()
        {
            if (_blogService.AddNewBlog(BlogForm))
            {
                BlogForm = new Blog();
                OnCreatePostDialogClose.InvokeAsync();
            }
        }
    }
}