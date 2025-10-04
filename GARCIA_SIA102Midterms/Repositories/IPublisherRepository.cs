using System.Collections.Generic;
using System.Threading.Tasks;
using GARCIA_SIA102Midterms.Models;

namespace GARCIA_SIA102Midterms.Repositories
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<Publisher>> GetAllAsync();
        Task<Publisher?> GetByIdAsync(string id);
        Task AddAsync(Publisher publisher);
        Task UpdateAsync(Publisher publisher);
        Task DeleteAsync(string id);
    }
}
