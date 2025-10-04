using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GARCIA_SIA102Midterms.Data;
using GARCIA_SIA102Midterms.Models;

namespace GARCIA_SIA102Midterms.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly pubsContext _context;

        public PublisherRepository(pubsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            return await _context.Publishers
                .Include(p => p.PubInfo) // optional, include PubInfo if needed
                .ToListAsync();
        }

        public async Task<Publisher?> GetByIdAsync(string id)
        {
            return await _context.Publishers
                .Include(p => p.PubInfo)
                .FirstOrDefaultAsync(p => p.PubId == id);
        }

        public async Task AddAsync(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                await _context.SaveChangesAsync();
            }
        }
    }
}
