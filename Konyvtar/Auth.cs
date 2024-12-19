using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Konyvtar
{
    public class Auth
    {
        private static User? _currentUser;

        public static bool Login(string username, string password)
        {
            var users = FileManager.LoadUsers();
            var hash = ComputeHash(password);
            _currentUser = users.FirstOrDefault(u => u.Username == username && u.PasswordHash == hash);
            return _currentUser != null;
        }
        public static void Logout()
        {
            _currentUser = null;
        }

        public static bool Register(string username, string password)
        {
            List<User> users = FileManager.LoadUsers();
            bool isAdmin = false;

            if (users.Count == 0) isAdmin = true;
            if (users.Any(x => x.Username == username)) return false;

            string passwordHash = ComputeHash(password);
            users.Add(new User(username, passwordHash, isAdmin));
            
            FileManager.SaveUsers(users);
            return true;
        }

        public static bool IsAdmin() => _currentUser?.IsAdmin ?? false;

        public static string ComputeHash(string text)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            return Convert.ToBase64String(bytes);
        }
    }
}
