using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Core.Models;
using Books.Core.Services;
using Books.Services;
using Xamarin.Forms;

namespace Books.ViewModels
{
    public class BooksViewModel : BaseViewModel
    {
        public ObservableCollection<Book> BooksList { get; set; }
        public Command LoadBooksCommand { get; }
        public Command AddBooksCommand { get; }
        public Command<Book> BookTapped { get; }

        private readonly BookService bookService;

        public BooksViewModel()
        {
            Title = "Books Library";

            bookService = new BookService();
            BooksList = new ObservableCollection<Book>();

            LoadBooksCommand = new Command(async() => await ExecuteLoadBooksCommand());
        }

        async Task ExecuteLoadBooksCommand()
        {
            IsBusy = true;
            try
            {
                BooksList.Clear();
                var books = await bookService.GetAllBooks();
                foreach (var b in books)
                {
                    foreach (var a in b.Authors)
                    {
                        Debug.WriteLine(a);
                    }
                    foreach (var g in b.Genres)
                    {
                        Debug.WriteLine(g);
                    }
                }
                
                foreach (var book in books)
                {
                    BooksList.Add(book);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
