using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Konyvtar
{
    public class UserManagementViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public User SelectedUser { get; set; }

        public UserManagementViewModel()
        {
            List<User> users = FileManager.LoadUsers();
            Users = new(users.Where(x => x.Username != Auth.CurrentUser.Username));
        }

        public void DeleteUser(User user)
        {
            Users.Remove(user);
            
            List<User> users = Users.ToList();
            users.Add(Auth.CurrentUser);
            
            FileManager.SaveUsers(users.ToList());
        }
    }
}
