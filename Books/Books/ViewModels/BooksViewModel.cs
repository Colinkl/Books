﻿using Books.Core.Models;
using Books.Services;
using Books.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Books.ViewModels
{
    public class BooksViewModel : BaseViewModel
    {

        public ObservableCollection<Book> BooksList { get; set; }
        public Command LoadBooksCommand { get; }
        public Command AddBooksCommand { get; }
        public Command<Book> BookTapped { get; }


        public BooksViewModel()
        {
            Title = "Books Library";
            BooksList = new ObservableCollection<Book>();


            BookTapped = new Command<Book>(OnBookSelected);
            LoadBooksCommand = new Command(async () => await ExecuteLoadBooksCommand());
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
    }
}
