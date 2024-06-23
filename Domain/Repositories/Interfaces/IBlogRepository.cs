using BloggerCMS.Domain.Models;

namespace BloggerCMS.Domain.Repositories.Interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Dictionary<Account, IEnumerable<Blog>>> GetBlogsAsync();
        Task<Blog> GetByIdAsync(int id);   
        Task AddAsync(Blog blog);
    }
}
