using Books.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Books.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewBookPage : ContentPage
    {
        public NewBookPage()
        {
            InitializeComponent();
            BindingContext = new NewBookViewModel();
        }


    }
}