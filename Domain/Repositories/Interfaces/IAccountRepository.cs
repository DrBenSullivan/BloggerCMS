using BloggerCMS.Domain.Models;

namespace BloggerCMS.Domain.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task AddAsync(Account account);
    }
}
