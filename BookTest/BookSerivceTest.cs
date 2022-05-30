using Microsoft.VisualStudio.TestTools.UnitTesting;
using Books.Services;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Books.Data;
using Microsoft.Data.Sqlite;
using Books.Core;
using Books.Core.Services;
using System.Threading.Tasks;
using System.Linq;

namespace BookTest
{
    [TestClass]
    public class BookSerivceTest
    {
        private readonly DbConnection _connection;
        private readonly DbContextOptions<LibraryDbContext> _contextOptions;

        public BookSerivceTest()
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
        IBookService CreateBookService() => new BookService(CreateUnitOfWork());

        [TestMethod]
        public async Task GetBookById()
        {
            var service = CreateBookService();
            var book1 = await service.GetBookById(1);

            Assert.AreEqual("Meow", book1.Title);

        }

        [TestMethod]
        public void  GetBookByTitle()
        {
            var service = CreateBookService();
            var book1 = service.GetBookByTitle("Woo").FirstOrDefault();

            Assert.AreEqual("Woof", book1.Title);
        }


    }
}
