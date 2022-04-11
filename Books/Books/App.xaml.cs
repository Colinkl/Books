using Books.Core;
using Books.Data;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace Books
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            using (var db = new LibraryDbContext())
            {
                db.Database.Migrate();
            }

            DependencyService.Register<LibraryDbContext>();
            DependencyService.Register<IUnitOfWork, UnitOfWork>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
