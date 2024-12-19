using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Konyvtar
{
    public class MainViewModel
    {
        public ObservableCollection<Book> Books { get; set; }
        public Book SelectedBook;

        public MainViewModel()
        {
            Books = new ObservableCollection<Book>(FileManager.LoadBooks());
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            FileManager.SaveBooks(Books.ToList());
        }

        public void UpdateBook(int index, Book book)
        {
            Books[index] = book;
            FileManager.SaveBooks(Books.ToList());
        }

        public void RemoveBook()
        {
            if (SelectedBook == null) return;
            Books.Remove(SelectedBook);
            FileManager.SaveBooks(Books.ToList());
        }
    }
}