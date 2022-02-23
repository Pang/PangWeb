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
        public DateTime LastLoginDt { get; set; }

        public List<ItemPurchase> Purchases { get; set; }
    }

    public class UserRegister
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
    }

    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}