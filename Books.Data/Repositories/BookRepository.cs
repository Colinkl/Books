using Books.Core.Models;
using Books.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace Books.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly LibraryDbContext dbContext;
        public BookRepository(LibraryDbContext context)
        {
            this.dbContext = context;
        }

        public IEnumerable<Book> BookSearch(string query)
        {
            var booksByAuthor = (from a in dbContext.Authors
                                 where a.Name.Contains(query) || a.LastName.Contains(query)
                                 select a.BookList.AsEnumerable()).FirstOrDefault();
            var booksByGenre = (from g in dbContext.Genres
                                where g.Name.StartsWith(query)
                                select g.Books).FirstOrDefault();
            var booksByTitle = (from b in dbContext.Books
                                where b.Title.StartsWith(query)
                                select b).ToList();
            var result = new List<Book>();
            if(booksByAuthor != null)
                result.AddRange(booksByAuthor);
            if(booksByGenre != null)
                result.AddRange(booksByGenre);
            if(booksByTitle != null) 
                result.AddRange(booksByTitle);
         
            result.Distinct();
            return result;

        }
        public async void UpdateBook(Book newBook)
        {
            var book = dbContext.Books
                .Include(b => b.Genres)
                .Include(b => b.Authors)
                .FirstOrDefault(b => b.Id == newBook.Id);
            dbContext.Entry(book).CurrentValues.SetValues(newBook);
            var bookGenres = book.Genres.ToList();
            foreach (var bookGenre in bookGenres)
            {
                var genre = newBook.Genres.FirstOrDefault(b => b.Id == bookGenre.Id);
                if (genre != null)
                    dbContext.Entry(bookGenre).CurrentValues.SetValues(genre);
                else
                    dbContext.Remove(bookGenre);
            }
            foreach (var genre in newBook.Genres)
            {
                if (bookGenres.All(i => i.Id != genre.Id))
                {
                    book.Genres.Add(genre);
                }
            }

            var bookAuthors = book.Authors.ToList();
            foreach (var bookAuthor in bookAuthors)
            {
                var author = newBook.Authors.FirstOrDefault(b => b.Id == bookAuthor.Id);
                if (author != null)
                    dbContext.Entry(bookAuthor).CurrentValues.SetValues(author);
                else
                    dbContext.Remove(bookAuthor);
            }
            foreach (var author in newBook.Authors)
            {
                if (bookAuthors.All(i => i.Id != author.Id))
                {
                    book.Authors.Add(author);
                }
            }
            await dbContext.SaveChangesAsync();
        }

    }
}
