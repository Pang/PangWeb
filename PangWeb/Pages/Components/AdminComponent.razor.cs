﻿using System.Net.Http.Json;
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

        protected override void OnInitialized() { }
    }
}