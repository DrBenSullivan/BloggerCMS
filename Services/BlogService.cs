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
        private readonly IAccountService _accountService;
        #endregion

        #region Constructors
        public BlogService(IBlogRepository blogRepository, IAccountService accountService)
        {
            _blogRepository = blogRepository;
            _accountService = accountService;
        }
        #endregion

        public async Task<IEnumerable<Account>> FetchAccountsAsync()
        {
            return await _accountService
                .FetchAccountsAsync()
                .ConfigureAwait(false);
        }

        public async Task<Dictionary<Account, IEnumerable<Blog>>> FetchBlogsAsync()
        {
            return await _blogRepository
                .GetBlogsAsync()
                .ConfigureAwait(false);
        }

        public async Task<Blog> FetchBlogByIdAsync(int id)
        {
            return await _blogRepository
                    .GetByIdAsync(id)
                    .ConfigureAwait(false);
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
