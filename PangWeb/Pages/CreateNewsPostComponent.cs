using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using PangWeb.Shared;

namespace PangWeb.Pages
{
    public partial class CreateNewsPostComponent
    {
        [Parameter]
        public NewsCard NewsCardForm { get; set; } = new NewsCard();

        protected override void OnInitialized()
        {
        }
    }
}