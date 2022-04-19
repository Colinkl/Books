using Books.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Books.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookDetailPage : ContentPage
    {
        public BookDetailPage()
        {
            InitializeComponent();
            BindingContext = new BookDetailViewModel();
        }
    }
}