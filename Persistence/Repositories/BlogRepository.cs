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

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await _context.Accounts
                .ToListAsync()
                .ConfigureAwait(false);
        }

		public async Task<Dictionary<Account, IEnumerable<Blog>>> GetBlogsAsync()
		{
			var groupedBlogs = await _context.Blogs
				.GroupBy(b => b.Author)
				.ToListAsync()
				.ConfigureAwait(false);

			return groupedBlogs.ToDictionary(g => g.Key, g => g.AsEnumerable());
		}

		public async Task<Blog> GetByIdAsync(int id)
        {
            var blog = await _context.Blogs
                .Include(b => b.BlogEntries)
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id)
                .ConfigureAwait(false);

            if (blog != null)
            {
                return blog;
            }

            throw new KeyNotFoundException($"Blog with id {id} not found");
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
