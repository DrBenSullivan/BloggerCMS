using BloggerCMS.Domain.Models;

namespace BloggerCMS.Domain.Services.Interfaces
{
    public interface IBlogService
    {
        Task<Dictionary<Account, List<Blog>>> FetchBlogsAsync();
        Task<Blog> FetchBlogByIdAsync(int id);
        Task<List<Account>> FetchAccountsAsync();
        Task<Blog> SaveBlogAsync(Blog blog);
    }
}
