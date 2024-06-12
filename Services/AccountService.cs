using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.Repositories.Interfaces;
using BloggerCMS.Domain.Services.Interfaces;

namespace BloggerCMS.Services
{
    public class AccountService: IAccountService
    {
        #region Private Properties
        private readonly IAccountRepository _accountRepository;
        #endregion

        #region Constructor
        public AccountService(IAccountRepository accountRepository) => _accountRepository = accountRepository;
        #endregion

        public async Task<IEnumerable<Account>> ListAccountsAsync()
        {
            return await _accountRepository
                .GetAllAsync()
                .ConfigureAwait(false);
        }
    }
}
