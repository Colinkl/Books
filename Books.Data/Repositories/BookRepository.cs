using Books.Core.Models;
using Books.Core.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

            /* There are a few limitations to be aware of when using raw SQL queries:

            - The SQL query must return data for all properties of the entity type.
            - The column names in the result set must match the column names that properties are mapped to.
                Note this behavior is different from EF6. EF6 ignored property to column mapping for raw 
                SQL queries and result set column names had to match the property names.
            - The SQL query can't contain related data. However, in many cases you can compose on 
                top of the query using the Include operator to return related data (see Including related data).
            */


            SqliteParameter parameter = new SqliteParameter("query", $"%{query}%");
            var books = Context.Books.FromSqlRaw(@"SELECT * FROM Books
                                                    WHERE Books.Id in
                                                        (SELECT DISTINCT Books.Id FROM Books 
                                                        JOIN BookGenre on Books.Id = BookGenre.BooksId
                                                        JOIN Genres on BookGenre.GenresId = Genres.Id
                                                        JOIN AuthorBook on Books.Id = AuthorBook.BookListId
                                                        JOIN Authors on AuthorBook.AuthorsId = Authors.Id
                                                        WHERE Books.Title || Genres.Name || Authors.Name || Authors.LastName LIKE @query)", parameter).AsEnumerable();
            return books;
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
