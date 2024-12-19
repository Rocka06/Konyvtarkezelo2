using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Konyvtar
{
    public class User
    {
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public bool IsAdmin { get; private set; }

        public User(string username, string passwordHash, bool isAdmin)
        {
            Username = username;
            PasswordHash = passwordHash;
            IsAdmin = isAdmin;
        }
    }
}
