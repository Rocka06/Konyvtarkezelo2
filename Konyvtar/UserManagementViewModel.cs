using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Konyvtar
{
    public class UserManagementViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public User SelectedUser { get; set; }

        public UserManagementViewModel()
        {
            Users = new(FileManager.LoadUsers());
        }

        public void DeleteUser(User user)
        {
            if(user.Username == Auth.CurrentUser.Username)
            {
                MessageBox.Show("Magadat nem törölheted!", "Hiba!");
                return;
            }

            Users.Remove(user);
            FileManager.SaveUsers(Users.ToList());
        }
    }
}
