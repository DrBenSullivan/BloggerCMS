using BloggerCMS.Domain.Models;

namespace BloggerCMS.Domain.Repositories.Interfaces
{
    public interface IBlogRepository
    {
        Task<List<Account>> GetAccountsAsync();
        Task<Dictionary<Account, List<Blog>>> GetBlogsAsync();
        Task<Blog> GetByIdAsync(int id);   
        Task AddAsync(Blog blog);
    }
}
