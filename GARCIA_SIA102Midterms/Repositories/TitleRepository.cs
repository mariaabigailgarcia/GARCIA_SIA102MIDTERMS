using GARCIA_SIA102Midterms.Data;
using GARCIA_SIA102Midterms.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GARCIA_SIA102Midterms.Repositories
{
    public class TitleRepository : ITitleRepository
    {
        private readonly pubsContext _context;

        public TitleRepository(pubsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Title>> GetAllAsync()
        {
            return await _context.Titles
                                 .Include(t => t.Pub)
                                 .Include(t => t.Titleauthors)
                                 .ThenInclude(ta => ta.Au)
                                 .ToListAsync();
        }

        public async Task<Title?> GetByIdAsync(string id)
        {
            return await _context.Titles
                                 .Include(t => t.Pub)
                                 .Include(t => t.Titleauthors)
                                 .ThenInclude(ta => ta.Au)
                                 .FirstOrDefaultAsync(t => t.TitleId == id);
        }

        public async Task AddAsync(Title title)
        {
            _context.Titles.Add(title);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Title title)
        {
            _context.Titles.Update(title);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var title = await _context.Titles.FindAsync(id);
            if (title != null)
            {
                _context.Titles.Remove(title);
                await _context.SaveChangesAsync();
            }
        }
    }
}
