using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Konyvtar
{
    public partial class UserManagement : Window
    {
        private UserManagementViewModel viewModel;

        public UserManagement()
        {
            InitializeComponent();
            viewModel = DataContext as UserManagementViewModel;
            
            if (!Auth.IsAdmin()) Close();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.SelectedUser == null) return;

            var result = MessageBox.Show($"Biztosan törli a(z) {viewModel.SelectedUser.Username} felhasználót?", "Törlés megerősítése", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                viewModel.DeleteUser(viewModel.SelectedUser);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UsersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.SelectedUser = (User)UsersListBox.SelectedItem;
        }
    }
}
