namespace PangWeb.Shared
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TotalOrderPrice { get; set; }
        public DateTimeOffset OrderPlacedDt { get; set; }
        public bool OrderComplete { get; set; }
        public bool Cancelled { get; set; }

        public User User { get; set; }
        public List<ItemPurchase> ItemPurchase { get; set; }
    }
}