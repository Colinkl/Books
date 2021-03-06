using Books.Views;
using Xamarin.Forms;

namespace Books
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BookDetailPage), typeof(BookDetailPage));
            Routing.RegisterRoute(nameof(NewBookPage), typeof(NewBookPage));
        }

    }
}
