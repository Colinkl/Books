using Books.Data;
using Books.Services;
using Books.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.EntityFrameworkCore;
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


            DependencyService.Register<MockDataStore>();
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
