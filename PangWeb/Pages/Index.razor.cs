using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using PangWeb.Services;
using PangWeb.Shared;

namespace PangWeb.Pages
{
    public partial class Index
    {
        [Inject]
        private BlogService _blogService { get; set; }
        public string Title = "PangWeb";


        protected async override void OnInitialized()
        {
            _blogService.blogs = await _blogService.GetAllBlogs();
            StateHasChanged();
        }
    }
}
