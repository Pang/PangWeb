using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using PangWeb.Services;
using PangWeb.Shared;

namespace PangWeb.Pages.Components
{
    public partial class CreateBlogComponent
    {
        [Inject]
        private BlogService _blogService { get; set; }

        [Parameter]
        public Blog BlogForm { get; set; } = new Blog();

        public void SavePostToList()
        {
            _blogService.AddNewBlog(BlogForm);
        }
    }
}