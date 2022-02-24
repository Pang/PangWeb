using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangWeb.Shared.DTOs
{
    public class UserDto
    {
        public UserDto() {}

        public UserDto(User user)
        {
            id = user.Id;
            email = user.Email;
            forename = user.Forename;
            surname = user.Surname;
            privilageLevel = user.PrivilageLevel;
        }

        public long id { get; set; }
        public string email { get; set; }
        public string forename { get; set; }
        public string surname { get; set; }
        public short privilageLevel { get; set; }
    }
}
