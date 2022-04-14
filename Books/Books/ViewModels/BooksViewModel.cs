using Books.Core.Models;
using Books.Services;
using Books.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;

namespace Books.ViewModels
{
    public class BooksViewModel : BaseViewModel
    {

        public ObservableCollection<Book> BooksList { get; set; }
        public Command LoadBooksCommand { get; }
        public Command AddBookCommand { get; }
        public Command<Book> BookTapped { get; }
        public Command<string> PerformSearch { get; }

        public BooksViewModel()
        {
            Title = "Books Library";
            BooksList = new ObservableCollection<Book>();

            BookTapped = new Command<Book>(OnBookSelected);
            AddBookCommand = new Command(OnBookAdd);
            LoadBooksCommand = new Command(async () => await ExecuteLoadBooksCommand());
            PerformSearch = new Command<string>(OnPerformSearchAsync);
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedBook = null;
        }


        private Book selectedBook;
        public Book SelectedBook
        {
            get => selectedBook;
            set
            {
                SetProperty(ref selectedBook, value);
                OnBookSelected(value);
            }
        }

        private async void OnBookAdd(Object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewBookPage));
        }

        private async void OnBookSelected(Book book)
        {
            if (book == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(BookDetailPage)}?{nameof(BookDetailViewModel.BookId)}={book.Id}");
        }


        async Task ExecuteLoadBooksCommand()
        {
            IsBusy = true;
            try
            {
                BooksList.Clear();
                var books = await bookService.GetAllBooks();
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

      
        

        private  void OnPerformSearchAsync(string query)
        {
            var books =  bookService.BookSearch(query);
            BooksList.Clear();
            foreach (var b in books)
            {
                BooksList.Add(b);
            } 
        }
    }
}
