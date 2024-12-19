using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Konyvtar
{
    public class User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }

        public User(string username, string passwordHash, bool isAdmin)
        {
            Username = username;
            PasswordHash = passwordHash;
            IsAdmin = isAdmin;
        }
    }
}
