using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class User
    {
        public User(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }

        public string UserName { get; set; }
        public string Email { get; set; }

        public string GetEmail(string email)
        {
            return $"Email-{email}";
        }

    }
}
