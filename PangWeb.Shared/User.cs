namespace PangWeb.Shared
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }

        public DateTimeOffset AccountCreationDt { get; set; }

        public List<ItemPurchase> Purchases { get; set; }
    }
