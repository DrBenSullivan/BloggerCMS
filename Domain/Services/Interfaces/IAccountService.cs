using BloggerCMS.Domain.Models;

namespace BloggerCMS.Domain.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> FetchAccountsAsync();
        Task<Account> SaveAccountAsync(Account account);
    }
}
