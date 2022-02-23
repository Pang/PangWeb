namespace PangWeb.Shared
{
    public class ItemPurchase
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int UserPurchasedFk { get; set; }
        public int ProductPurchasedFk { get; set; }
        public string PricePurchased { get; set; }
        public DateTimeOffset PurchaseDt { get; set; }
        public bool refunded { get; set; }
        public DateTimeOffset? refundedDt { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
    }
}