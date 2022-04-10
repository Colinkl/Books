using Books.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Core.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(int id);
        Task<Author> CreateAuthor(Author newAuthor);
        Task UpdateAuthor(Author AuthorToBeUpdated, Author Author);
        Task DeleteAuthor(Author Author);
    }
}
