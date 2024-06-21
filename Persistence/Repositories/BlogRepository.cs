using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.Repositories.Interfaces;
using BloggerCMS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BloggerCMS.Persistence.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        #region Private Properties
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructors
        public BlogRepository(ApplicationDbContext context) => _context = context;
        #endregion

        public async Task<List<Account>> GetAccountsAsync()
        {
            return await _context.Accounts
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<Dictionary<Account, List<Blog>>> GetBlogsAsync()
        {
            return await _context.Blogs
                .GroupBy(b => b.Author)
                .ToDictionaryAsync(g => g.Key, g => g.ToList())
                .ConfigureAwait(false);
        }

        public async Task<Blog?> FindByIdAsync(int id)
        {
            return await _context.Blogs
                .Where(a => id == a.Id)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }

        public async Task AddAsync(Blog blog)
        {
            try
            {
                Console.WriteLine($"Attempting to add {blog} to Db");
				var blogAdded = await _context.Blogs
                    .AddAsync(blog)
                    .ConfigureAwait(false);
                _context.SaveChanges();
			}
            catch (Exception ex)
            {
                Console.Write($"Failed to add to Db {ex.Message}");
                throw new DbUpdateException(ex.Message, ex);
            }
        }
    }
}
