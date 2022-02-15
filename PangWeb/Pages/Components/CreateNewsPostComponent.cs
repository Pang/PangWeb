using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using PangWeb.Services;
using PangWeb.Shared;

namespace PangWeb.Pages.Components
{
    public partial class CreateNewsPostComponent
    {
        [Inject]
        private BlogService _blogService { get; set; }

        [Parameter]
        public NewsCard NewsCardForm { get; set; } = new NewsCard();

        protected override void OnInitialized()
        {
        }

        public void SavePostToList()
        {
            NewsCardForm.Date = DateTimeOffset.Now;
            _blogService.NewsCards.Add(NewsCardForm);
        }
    }
}