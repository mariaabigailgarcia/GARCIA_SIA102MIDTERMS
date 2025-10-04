using System.Collections.Generic;
using System.Threading.Tasks;
using GARCIA_SIA102Midterms.Models;

namespace GARCIA_SIA102Midterms.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(string id);
        Task AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(string id);
    }
}
