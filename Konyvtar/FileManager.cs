using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace Konyvtar
{
    public static class FileManager
    {
        private static readonly string booksFilePath = "books.json";
        private static readonly string usersFilePath = "users.json";

        public static List<Book> LoadBooks()
        {
            if (!File.Exists(booksFilePath)) return new List<Book>();
            string json = File.ReadAllText(booksFilePath);
            return JsonSerializer.Deserialize<List<Book>>(json);
        }

        public static void SaveBooks(List<Book> books)
        {
            string json = JsonSerializer.Serialize(books);
            File.WriteAllText(booksFilePath, json);
        }

        public static List<User> LoadUsers()
        {
            if (!File.Exists(usersFilePath)) return new List<User>();
            string json = File.ReadAllText(usersFilePath);
            return JsonSerializer.Deserialize<List<User>>(json);
        }

        public static void SaveUsers(List<User> users)
        {
            string json = JsonSerializer.Serialize(users);
            File.WriteAllText(usersFilePath, json);
        }
    }
}
