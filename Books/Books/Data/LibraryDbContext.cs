using Books.Data.Models;
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

        public DbSet<Location> Locations { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

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


    }
}
