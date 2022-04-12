using Books.Services;
using Xamarin.Forms;
using Books.Core.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Linq;
namespace Books.ViewModels
{

    [QueryProperty(nameof(BookId), nameof(BookId))]
    public class BookDetailViewModel : BaseViewModel
    {

        private int bookId;
        public int BookId
        {
            get
            {
                return bookId;
            }
            set
            {
                bookId = value;
                LoadBookId(value);
            }
        }

        public int Id { get; set; }




        private string bookTitle;
        public string BookTitle
        {
            get { return bookTitle; }
            set { SetProperty(ref bookTitle, value); }
        }

        private string bookLocation;
        public string BookLocation { get { return bookLocation; } set { SetProperty( ref bookLocation, value); } }


        private string bookDescription;
        public string BookDescription { get { return bookDescription; } set { SetProperty(ref bookDescription, value); } }
        
        private string bookImage;
        public string BookImage { get { return bookImage; } set { SetProperty(ref bookImage, value);} }
        public ObservableCollection<Author> Authors { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }



        private Book book;
        public async void LoadBookId(int itemId)
        {
            try
            {
                book = await bookService.GetBookById(itemId);
                
                BookTitle = book.Title;
                BookLocation = book.Location.ToString();
                BookDescription = book.Descripton;
                BookImage = book.Image;
                book.Authors.ForEach(x =>
                {
                    Authors.Add(x);
                });
                book.Genres.ForEach(x =>
                {
                    Genres.Add(x);
                });

            }
            catch (System.Exception)
            {

                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
