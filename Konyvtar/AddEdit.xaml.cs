using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Konyvtar
{
    public partial class AddEdit : Window
    {
        public Book Book { get; private set; }
        public int? Index { get; private set; }

        public AddEdit(int? index = null, Book book = null)
        {
            InitializeComponent();
            Book = book ?? new Book("", "", 0, "");
            Index = index;

            TitleTextBox.Text = Book.Title;
            AuthorTextBox.Text = Book.Author;
            YearTextBox.Text = Book.PublicationYear.ToString();
            CategoryComboBox.SelectedItem = Book.Category;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text) || string.IsNullOrWhiteSpace(AuthorTextBox.Text))
            {
                MessageBox.Show("A könyv címe és szerzője kötelező!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(YearTextBox.Text, out int year) || year < 1800 || year > DateTime.Now.Year)
            {
                MessageBox.Show($"A kiadási évnek számnak kell lennie 1800 és {DateTime.Now.Year} között!",
                                "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Book = new(TitleTextBox.Text, AuthorTextBox.Text, year, CategoryComboBox.Text);

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
