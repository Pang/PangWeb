namespace PangWeb.Shared
{
    public class NewsCard
    {
        public NewsCard()
        {
        }

        public string Title { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Summary { get; set; }
    }
}