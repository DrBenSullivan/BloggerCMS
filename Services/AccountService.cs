using System.Security.Principal;
using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.Repositories.Interfaces;
using BloggerCMS.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BloggerCMS.Services
{
    public class AccountService : IAccountService
    {
        #region Private Properties
        private readonly IAccountRepository _accountRepository;
        #endregion

        #region Constructor
        public AccountService(IAccountRepository accountRepository) => _accountRepository = accountRepository;
        #endregion

        public async Task<IEnumerable<Account>> FetchAccountsAsync()
        {
            return await _accountRepository
                .GetAllAsync()
                .ConfigureAwait(false);
        }

        public async Task<Account> FetchAccountByIdAsync(int id)
        {
            return await _accountRepository
                .GetByIdAsync(id)
                .ConfigureAwait(false);
        }

        public async Task<Account> SaveAccountAsync(Account newAccount)
        {
            await _accountRepository
                .AddAsync(newAccount)
                .ConfigureAwait(false);
            return newAccount;
        }
    }
}
