using Books.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "data.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StorageUnit>().HasData(
                new StorageUnit[]
                {
                    new StorageUnit {Id= 1, Rack = 1, Row = 1, Shelf = 1 },
                    new StorageUnit { Id = 2, Rack = 1, Row = 2, Shelf = 1 },
                    new StorageUnit {Id = 3, Rack = 2, Row = 1, Shelf = 2 },
                    new StorageUnit {Id = 4, Rack = 2, Row = 2, Shelf= 1 }
                });
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author { Id = 1, Name ="A", LastName = "A"},
                new Author {Id = 2, Name ="B", LastName = "B"},
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
                new User { Id = 2, Name ="Customer", Key = "0000", Image = "https://www.shadertoy.com/media/users/hvhnts/profile.jpeg"}

            });
            modelBuilder.Entity<Book>().HasData(new Book[]
            {
                new Book { Id = 1,
                    Title ="Interesting Book",
                    LocationId = 1, AddedByUserId = 1,
                    Descripton = "SuperBook",
                    Image = "https://www.uselessthingstobuy.com/wp-content/uploads/2019/05/Screen-Shot-2019-05-22-at-11.50.41-AM.png"}
                });
            modelBuilder.Entity<Book>()
                .HasMany(p => p.Genres)
                .WithMany(t => t.Books)
                .UsingEntity<Dictionary<string, object>>(
                "BookGenre",
                r => r.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                l => l.HasOne<Book>().WithMany().HasForeignKey("BookId"),
                je =>
                {
                    je.HasKey("BookId", "GenreId");
                    je.HasData(
                        new { BookId = 1, GenreId = 1 },
                        new { BookId = 1, GenreId = 2 });
                });
            modelBuilder.Entity<Book>()
                .HasMany(p => p.Authors)
                .WithMany(t => t.BookList)
                .UsingEntity<Dictionary<string, object>>(
                "BookAuthor",
                r => r.HasOne<Author>().WithMany().HasForeignKey("AuthorId"),
                l => l.HasOne<Book>().WithMany().HasForeignKey("BookId"),
                je =>
                {
                    je.HasKey("BookId", "AuthorId");
                    je.HasData(
                        new { BookId = 1, AuthorId = 1 },
                        new { BookId = 1, AuthorId = 2 });
                });

        }



    }

}
