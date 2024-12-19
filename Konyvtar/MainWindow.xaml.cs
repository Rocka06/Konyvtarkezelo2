using System.Text;
using System.Windows;

namespace Konyvtar
{
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = DataContext as MainViewModel;

            UsersButton.Visibility = Auth.IsAdmin() ? Visibility.Visible : Visibility.Hidden;
            EditButton.Visibility = Auth.IsAdmin() ? Visibility.Visible : Visibility.Hidden;
            DeleteButton.Visibility = Auth.IsAdmin() ? Visibility.Visible : Visibility.Hidden;
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            UserManagement window = new UserManagement();
            window.ShowDialog();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            var addBookWindow = new AddEdit();
            if (addBookWindow.ShowDialog() == true)
            {
                viewModel.AddBook(addBookWindow.Book);
            }
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            if (!Auth.IsAdmin()) return;
            if (viewModel.SelectedBook == null)
            {
                MessageBox.Show("Nincs kiválasztott könyv!", "Hiba!");
                return;
            }
            
            AddEdit editBookWindow = new AddEdit(viewModel.Books.IndexOf(viewModel.SelectedBook), viewModel.SelectedBook);
            if (editBookWindow.ShowDialog() == true)
            {
                viewModel.UpdateBook((int)editBookWindow.Index, editBookWindow.Book);
            }
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if (!Auth.IsAdmin()) return;
            if (viewModel.SelectedBook == null)
            {
                MessageBox.Show("Nincs kiválasztott könyv!", "Hiba!");
                return;
            }

            viewModel.RemoveBook();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = new();
            Login login = new();

            Auth.Logout();
            login.Show();
            Close();
        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            viewModel.SelectedBook = BooksListBox.SelectedItem as Book;
        }

    }
}