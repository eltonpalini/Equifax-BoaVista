using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public int Id { get; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
