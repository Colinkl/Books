using Books.Core;
using Books.Core.Models;
using Books.Core.Services;
using Books.Data;
using Books.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BookTest
{
    [TestClass]
    public class AuthorServiceTest
    {
        private readonly DbConnection _connection;
        private readonly DbContextOptions<LibraryDbContext> _contextOptions;

        public AuthorServiceTest()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _contextOptions = new DbContextOptionsBuilder<LibraryDbContext>()
            .UseSqlite(_connection)
            .Options;

            using var context = new LibraryDbContext(_contextOptions);

        }

        LibraryDbContext CreateContext() => new LibraryDbContext(_contextOptions);
        IUnitOfWork CreateUnitOfWork() => new UnitOfWork(CreateContext());
        IAuthorService CreateBookService() => new AuthorService(CreateUnitOfWork());

        [TestMethod]
        public async Task GetAllAuthors()
        {
            var service = CreateBookService();
            var result = await service.GetAllAuthors();
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.ToList().Count);
        }

        [TestMethod]
        public async Task GetAuthorByID()
        {
            var service = CreateBookService();
            var result = await service.GetAuthorById(3);
            Assert.IsNotNull(result);
            Assert.AreEqual("C", result.Name);
        }
    }
}
