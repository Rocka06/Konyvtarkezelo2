using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Konyvtar
{
    public partial class Login : Window
    {

        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            bool result = Auth.Login(username, password);

            if (result)
            {
                MainWindow mainWindow = new();
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Helytelen felhasználónév vagy jelszó!", "Hiba");
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new();
            registerWindow.ShowDialog();
        }
    }
}
