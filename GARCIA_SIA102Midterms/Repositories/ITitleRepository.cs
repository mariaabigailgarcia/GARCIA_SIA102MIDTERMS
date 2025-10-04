using GARCIA_SIA102Midterms.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GARCIA_SIA102Midterms.Repositories
{
    public interface ITitleRepository
    {
        Task<IEnumerable<Title>> GetAllAsync();
        Task<Title?> GetByIdAsync(string id);
        Task AddAsync(Title title);
        Task UpdateAsync(Title title);
        Task DeleteAsync(string id);
    }
}
