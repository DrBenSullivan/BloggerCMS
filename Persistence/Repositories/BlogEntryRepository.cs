using BloggerCMS.Persistence.Contexts;
using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.Repositories.Interfaces;

namespace BloggerCMS.Persistence.Repositories
{
    public class BlogEntryRepository : IBlogEntryRepository
    {
        private readonly ApplicationDbContext _context;

        #region Constructor
        public BlogEntryRepository(ApplicationDbContext context) => _context = context;
        #endregion

        public async Task<BlogEntry> GetByIdAsync(int id)
        {
            var blogEntryExists = await _context.BlogEntries.FindAsync(id);

            if (blogEntryExists != null)
            {
                return blogEntryExists;
            }

            throw new KeyNotFoundException($"Blog entry with Id {id} not found.");
        }
    }
}
