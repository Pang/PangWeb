﻿using System.Net.Http.Json;
using PangWeb.Shared;

namespace PangWeb.Pages
{
    public partial class Index
    {
        public List<NewsCard> NewsCards;

        protected override void OnInitialized()
        {
            //NewsCards = new List<NewsCard> (await Http.GetFromJsonAsync<List<NewsCard>>("sample-data/news.json"));
            InitializeData();
        }

        private void InitializeData()
        {
            NewsCards = new List<NewsCard>()
            {
                new NewsCard { 
                    Title = "New stuff",  
                    Date = "2021-01-17",
                    Summary = "We gon be workin on a new game, LOTR-inspired with castles and fantasy stuff. Based in the same universe as ShieldMaidens"
                },
                new NewsCard {
                    Title = "In other news",
                    Date = "2021-01-17",
                    Summary = "This is a cool summary"
                },
                new NewsCard {
                    Title = "Just keep scrollin",
                    Date = "2020-05-11",
                    Summary = "It really goes on..."
                },
            };
        }
    }
}
