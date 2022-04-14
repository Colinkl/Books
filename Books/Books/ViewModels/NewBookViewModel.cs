using Books.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;
namespace Books.ViewModels
{
    public class NewBookViewModel : BaseViewModel
    {
        private string bookTitle = string.Empty;
        public string BookTitle
        {
            get => bookTitle;
            set => SetProperty(ref bookTitle, value);
        }


        private string bookDescription;
        public string BookDescription
        {
            get => bookDescription;
            set => SetProperty(ref bookDescription, value);
        }

        private string bookTitlePlaceHolder;
        public string BookTitlePlaceHolder { get => bookTitlePlaceHolder; set => SetProperty(ref bookTitlePlaceHolder, value); }

        public ObservableCollection<Author> SelectedAuthorsList { get; set; }
        public ObservableCollection<Author> Authors { get; set; }

        public ObservableCollection<Genre> Genres { get; set; }
        public ObservableCollection<Genre> SelectedGenresList { get; set; }

        public ObservableCollection<StorageUnit> LocationsList { get; set; }
        private StorageUnit selectedLocation;
        public StorageUnit SelectedLocation
        {
            get
            {
                if (selectedLocation == null)
                    LoadLocations();
                return selectedLocation;
            }
            set => SetProperty(ref selectedLocation, value);
        }

        private bool authorSelectPopupVisible = false;
        public bool AuthorSelectPopupVisible { get => authorSelectPopupVisible; set => SetProperty(ref authorSelectPopupVisible, value); }

        private bool genresSelectPopupVisible;
        public bool GenresSelectPopupVisible { get => genresSelectPopupVisible; set => SetProperty(ref genresSelectPopupVisible, value); }

        public Command<Author> RemoveAuthorCommand { get; }
        public Command AddAuthorCommand { get; }


        private Author selectedAuthor;
        public Author SelectedAuthor
        {
            get => selectedAuthor;
            set
            {
                if (value == null)
                    return;

                SetProperty(ref selectedAuthor, value);
                OnAuthorSelected(value);

            }
        }

        private Genre selectedGenre;
        public Genre SelectedGenre
        {
            get => selectedGenre;
            set
            {
                if (value == null)
                    return;

                SetProperty(ref selectedGenre, value);
                OnGenreSelected(value);

            }
        }

        public Command<Genre> RemoveGenreCommand { get; }
        public Command AddGenreCommand { get; }

        public Command SaveCommand { get; }
        public NewBookViewModel()
        {
            selectedAuthor = null;
            selectedGenre = null;
            SelectedAuthorsList = new ObservableCollection<Author>();
            SelectedGenresList = new ObservableCollection<Genre>();
            Authors = new ObservableCollection<Author>();
            Genres = new ObservableCollection<Genre>();
            LocationsList = new ObservableCollection<StorageUnit>();

            AddAuthorCommand = new Command(OnAuthorAdd);
            RemoveAuthorCommand = new Command<Author>(OnAuthorRemove);

            AddGenreCommand = new Command(OnGenreAdd);
            RemoveGenreCommand = new Command<Genre>(OnGenreRemove);

            SaveCommand = new Command(OnBookSave);

        }

        private async void OnBookSave()
        {
            try
            {
                if (bookTitle == string.Empty)
                {
                    BookTitlePlaceHolder = "Required";
                    return;
                }
                var book = new Book()
                {
                    Title = bookTitle,
                    Descripton = bookDescription,
                    Authors = SelectedAuthorsList.ToList(),
                    Genres = SelectedGenresList.ToList(),
                    AddedByUserId = 0,
                    Location = selectedLocation
                };
                await bookService.CreateBook(book);
                await Shell.Current.GoToAsync("..");

            }
            catch (System.Exception)
            {

                BookTitlePlaceHolder = "error";
            }


            
        }

        private async void LoadLocations()
        {
            var locations = await bookService.GetAllStorageUnitsAsync();
            foreach (var l in locations)
            {
                LocationsList.Add(l);
            }
        }

        private void OnAuthorRemove(Author author)
        {
            try
            {
                SelectedAuthorsList.Remove(author);
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        private void OnGenreRemove(Genre genre)
        {
            try
            {
                SelectedGenresList.Remove(genre);
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        private async void OnAuthorAdd()
        {
            try
            {
                Authors.Clear();
                var authors = await authorService.GetAllAuthors();
                foreach (var a in authors)
                {
                    if (SelectedAuthorsList.Contains(a))
                    {
                        continue;
                    }
                    Authors.Add(a);
                }
                if (Authors.Count > 0)
                    AuthorSelectPopupVisible = true;

            }
            catch (System.Exception)
            {

                throw;
            }

        }

        private async void OnGenreAdd()
        {
            try
            {
                Genres.Clear();
                var genres = await bookService.GetAllGenres();
                foreach (var g in genres)
                {
                    if (SelectedGenresList.Contains(g))
                    {
                        continue;
                    }
                    Genres.Add(g);
                }
                if (Genres.Count > 0)
                    GenresSelectPopupVisible = true;

            }
            catch (System.Exception)
            {

                throw;
            }

        }

        private void OnGenreSelected(Genre genre)
        {
            try
            {
                SelectedGenresList.Add(genre);
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                GenresSelectPopupVisible = false;
            }
        }

        private void OnAuthorSelected(Author author)
        {
            try
            {
                SelectedAuthorsList.Add(author);
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                AuthorSelectPopupVisible = false;
            }


        }
    }
}
