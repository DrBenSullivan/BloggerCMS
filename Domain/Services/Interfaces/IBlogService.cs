using BloggerCMS.Domain.Models;

namespace BloggerCMS.Domain.Services.Interfaces
{
    public interface IBlogService
    {
        Task<Dictionary<Account, IEnumerable<Blog>>> FetchBlogsAsync();
        Task<Blog> FetchBlogByIdAsync(int id);
        Task<IEnumerable<Account>> FetchAccountsAsync();
        Task<Blog> SaveBlogAsync(Blog blog);
    }
}
