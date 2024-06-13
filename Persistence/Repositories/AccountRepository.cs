using BloggerCMS.Persistence.Contexts;
using BloggerCMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using BloggerCMS.Domain.Repositories.Interfaces;

namespace BloggerCMS.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        #region Private Properties
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public AccountRepository(ApplicationDbContext context) => _context = context;
        #endregion

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts
                .Include(a => a.Blogs)
                .ThenInclude(b => b.BlogEntries)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task AddAsync(Account account)
        {
            Console.WriteLine("Account repository attempting to add newAccount");
            try
            {
                await _context.Accounts
                    .AddAsync(account)
                    .ConfigureAwait(false);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding to Db");
            }
        }
        

    }
}
