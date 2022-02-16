namespace PangWeb.Shared
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Summary { get; set; }
    }
}