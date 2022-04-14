using Books.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Core.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        void UpdateBook(Book newBook);
        IEnumerable<Book> BookSearch(string query);
    }
}
