using Books.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Xamarin.Essentials;

namespace Books.Data
{

    public class LibraryDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<StorageUnit> StorageUnits { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<User> Users { get; set; }



        public LibraryDbContext()
        {
            SQLitePCL.Batteries_V2.Init();
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "data.db3");

            optionsBuilder
                .UseLazyLoadingProxies()
                .EnableSensitiveDataLogging()
                .UseSqlite($"Filename={dbPath}")
                .LogTo(System.Console.WriteLine);


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StorageUnit>().HasData(
                new StorageUnit[]
                {
                    new StorageUnit {Id = 1, Rack = 1, Row = 1, Shelf = 1 },
                    new StorageUnit {Id = 2, Rack = 1, Row = 2, Shelf = 1 },
                    new StorageUnit {Id = 3, Rack = 2, Row = 1, Shelf = 2 },
                    new StorageUnit {Id = 4, Rack = 2, Row = 2, Shelf = 1 }
                });
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author { Id = 1, Name ="M.E.", LastName = "Owmeow"},
                new Author { Id = 2, Name ="W.O.", LastName = "OofWoof"},
                new Author { Id=3, Name ="C", LastName = "C"},
                new Author { Id=4, Name ="D", LastName = "D"}
            });
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre { Id = 1, Name = "Comedy"},
                new Genre {Id = 2, Name ="Drama" },
                new Genre {Id = 3, Name ="Test" }
            });
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User { Id = 1, Name ="Test1", Key = "1234", Image= "https://i.ibb.co/KbPZtXK/A0-LXMSyhr-F4.jpg"},
                new User { Id = 10, Name ="Customer", Key = "0000", Image = "https://www.shadertoy.com/media/users/hvhnts/profile.jpeg"}

            });
            modelBuilder.Entity<Book>().HasData(new Book[]
            {
                new Book { Id = 1,
                    Title ="Meow",
                    LocationId = 1, AddedByUserId = 1,
                    Descripton = "Meow is a novel for cats written from the perspective of a cat. Only one word can describe the wondrous adventures waiting inside the cover of Meow, and that word is Meow. Meow is also the only word you will find inside the cover of Meow, because this is a novel for cats",
                    Image = "https://www.uselessthingstobuy.com/wp-content/uploads/2019/05/Screen-Shot-2019-05-22-at-11.50.41-AM.png"}
                });
            modelBuilder.Entity<Book>().HasData(new Book[]
            {
                new Book { Id = 2,
                    Title ="Woof",
                    LocationId = 2, AddedByUserId = 1,
                    Descripton = "Woof is a novel for dogs written from the perspective of a dog Only one word can describe the wondrous adventures waiting inside the cover of Woof, it is also the only word you will find inside the cover of Woof. Woof",
                    Image = "https://images-na.ssl-images-amazon.com/images/I/41wCjqWKq5L.jpg"}
               });

            modelBuilder.Entity("BookGenre").HasData(
                new { BooksId = 1, GenresId = 1 },
                new { BooksId = 1, GenresId = 2 },
                new { BooksId = 2, GenresId = 2 },
                new { BooksId = 2, GenresId = 3 });
            modelBuilder.Entity("AuthorBook").HasData(
                new { AuthorsId = 1, BookListId = 1 },
                new { AuthorsId = 1, BookListId = 2 },
                new { AuthorsId = 2, BookListId = 2 });

        }



    }

}
