namespace PangWeb.Shared
{
    public class ItemPurchase
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long UserPurchasedId { get; set; }
        public long ProductPurchasedId { get; set; }
        public string PricePurchased { get; set; }
        public DateTimeOffset PurchaseDt { get; set; }
        public bool refunded { get; set; }
        public DateTimeOffset? refundedDt { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
    }
}