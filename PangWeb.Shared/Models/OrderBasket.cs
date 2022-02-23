namespace PangWeb.Shared
{
    public class OrderBasket
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public List<Product> Products { get; set; }
        public string TotalOrderPrice { get; set; }
        public DateTimeOffset LastUpdatedDt { get; set; }

        public User User { get; set; }
    }
}
