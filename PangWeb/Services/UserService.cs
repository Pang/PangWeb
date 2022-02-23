using PangWeb.Shared;

namespace PangWeb.Services
{
    public class UserService
    {
        private List<User> _users;

        public UserService()
        {
            _users = SeededData();
        }

        private List<User> SeededData()
        {
            Random rand = new Random();
            return new List<User>()
            {
                new User
                {
                    Id = 1,
                    Email = "lorem@ipsum.dolor",
                    Forename = "John",
                    Surname = "Smith",
                    AccountCreationDt = new DateTimeOffset()
                },
            };
        }
    }
}
