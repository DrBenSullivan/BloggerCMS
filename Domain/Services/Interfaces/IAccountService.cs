using BloggerCMS.Domain.Models;

namespace BloggerCMS.Domain.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> ListAccountsAsync();
        Task<Account> AddAccountAsync(Account account);
    }
}
