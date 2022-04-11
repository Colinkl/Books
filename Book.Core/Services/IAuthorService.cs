using Books.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Core.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(int id);
        IEnumerable<Author> FindAuthorByName(string name);
        Task CreateAuthor(Author newAuthor);
        Task UpdateAuthor(Author Author);
        Task DeleteAuthor(Author Author);
    }
}
