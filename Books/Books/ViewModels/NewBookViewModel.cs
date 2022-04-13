using Books.Core.Models;
using Books.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Books.ViewModels
{
    public class NewBookViewModel : BaseViewModel
    {
        private string bookTitle;
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

        private List<Author> selectedAuthorsList;
        public ObservableCollection<Author> SelectedAuthorsList { get; set; }

        private List<Genre> selectedGenresList;
        public ObservableCollection<Genre> SelectedGenresList { get; set; }

        public List<StorageUnit> LocationsList { get; set; }
        private StorageUnit selectedLocation;
        public StorageUnit SelectedLocation { get => selectedLocation; set => SetProperty(ref selectedLocation, value); }

        public Command<Author> RemoveAuthorClicked { get; }
        public Command AddAuthorClicked { get; }

        public Command<Genre> RemoveGenreClicked { get; }
        public Command AddGenreClicked { get; }
        public NewBookViewModel()
        {

        }



    }
}
