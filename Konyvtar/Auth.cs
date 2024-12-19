using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Konyvtar
{
    public class Auth
    {
        public static User? CurrentUser { get; private set; }

        public static bool Login(string username, string password)
        {
            var users = FileManager.LoadUsers();
            var hash = ComputeHash(password);
            CurrentUser = users.FirstOrDefault(u => u.Username == username && u.PasswordHash == hash);
            return CurrentUser != null;
        }
        public static void Logout()
        {
            CurrentUser = null;
        }
        public static bool Register(string username, string email, string password, out string message)
        {
            List<User> users = FileManager.LoadUsers();
            message = "Sikeres regisztráció!";
            bool isAdmin = users.Count == 0;

            if (users.Any(x => x.Username == username))
            {
                message = "Ez a felhasználónév már foglalt!";
                return false;
            }
            if (!IsValidEmail(email))
            {
                message = "Az email formátuma nem érvényes.";
                return false;
            }
            if (!IsValidPassword(password))
            {
                message = "A jelszó legalább 8 karakter hosszú, tartalmaznia kell egy nagybetűt, egy kisbetűt és egy számot.";
                return false;
            }

            string passwordHash = ComputeHash(password);
            users.Add(new User(username, email, passwordHash, isAdmin));
            
            FileManager.SaveUsers(users);
            return true;
        }

        public static bool IsAdmin() => CurrentUser?.IsAdmin ?? false;
        
        private static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        private static bool IsValidPassword(string password)
        {
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            return password.Length >= 8 && hasUpperCase && hasLowerCase && hasDigit;
        }
        
        public static string ComputeHash(string text)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            return Convert.ToBase64String(bytes);
        }
    }
}
