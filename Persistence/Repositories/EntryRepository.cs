using BloggerCMS.Persistence.Contexts;
using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BloggerCMS.Persistence.Repositories
{
    public class EntryRepository : IEntryRepository
    {
        #region private properties
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public EntryRepository(ApplicationDbContext context) => _context = context;
        #endregion


        public async Task<IEnumerable<BlogEntry>> GetRecentEntriesAsync(int count)
        {
            var blogEntries = await _context.BlogEntries
                .OrderBy(b => b.DatePosted)
                .Take(count)
                .Include(b => b.Blog)
                .ThenInclude(b => b.Author)
                .ToListAsync()
                .ConfigureAwait(false);

            if (blogEntries != null)
            {
                return blogEntries;
            }

            throw new Exception("No blogEntries retrieved from database.");
        }

        public async Task<BlogEntry> GetByIdAsync(int id)
        {
            var blogEntryExists = await _context.BlogEntries
                .Include(b => b.Blog)
                .ThenInclude(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id)
                .ConfigureAwait(false);

            if (blogEntryExists == null)
            {
                throw new KeyNotFoundException($"Blog entry with Id {id} not found.");
            }

            return blogEntryExists;
        }

        public async Task AddAsync(BlogEntry entry)
        {
            try
            {
                await _context.BlogEntries
                    .AddAsync(entry)
                    .ConfigureAwait(false);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DbUpdateException(ex.Message, ex);
            }
        }
    }
}
