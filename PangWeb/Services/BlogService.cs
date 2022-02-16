using PangWeb.Shared;

namespace PangWeb.Services
{
    public class BlogService
    {
        public List<NewsCard>? NewsCards = new List<NewsCard>();

        public BlogService()
        {
            NewsCards = new List<NewsCard>()
            {
                new NewsCard {
                    Title = "New stuff",
                    Date = DateTimeOffset.Parse("17/01/2021"),
                    Summary = "We gon be workin on a new game, LOTR-inspired with castles and fantasy stuff. Based in the same universe as ShieldMaidens"
                },
                new NewsCard {
                    Title = "In other news", 
                    Date = DateTimeOffset.Parse("14/03/2017"),
                    Summary = "This is a cool summary"
                },
                new NewsCard
                {
                    Title = "Just keep scrollin",
                    Date = DateTimeOffset.Parse("11/05/2015"),
                    Summary = "It really goes on..."
                },
            };
        }
    }
}
