namespace PangWeb.Shared
{
    public class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }

        public DateTime AccountCreationDt { get; set; }
        public DateTime LastLoginDt { get; set; }

        public List<ItemPurchase> Purchases { get; set; }
        public short PrivilageLevel { get; set; }
    }
}