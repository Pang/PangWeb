namespace PangWeb.Shared
{
    public class Blog
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ImgUrl { get; set; }
        public bool Active { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}