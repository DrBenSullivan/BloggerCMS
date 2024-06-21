using BloggerCMS.Persistence.Contexts;
using BloggerCMS.Domain.Repositories.Interfaces;
using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.Services.Interfaces;

namespace BloggerCMS.Services
{
    public class BlogService : IBlogService
    {
        #region Private Properties
        private readonly IBlogRepository _blogRepository;
        #endregion

        #region Constructors
        public BlogService(IBlogRepository blogRepository) => _blogRepository = blogRepository;
        #endregion

        public async Task<List<Account>> FetchAccountsAsync()
        {
            return await _blogRepository
                .GetAccountsAsync()
                .ConfigureAwait(false);
        }

        public async Task<Dictionary<Account, List<Blog>>> FetchBlogsAsync()
        {
            return await _blogRepository
                .GetBlogsAsync()
                .ConfigureAwait(false);
        }

        public async Task<Blog> FetchBlogByIdAsync(int id)
        {
            var blogExists = await _blogRepository
                    .FindByIdAsync(id)
                    .ConfigureAwait(false);

            if (blogExists != null)
            {
                return blogExists;
            }

            throw new KeyNotFoundException($"Blog with id {id} not found");
        }

        public async Task<Blog> SaveBlogAsync(Blog blog)
        {
            Console.WriteLine($"Sending {blog} to repository");
			await _blogRepository
	            .AddAsync(blog)
	            .ConfigureAwait(false);
            return blog;
        }
    }
}
