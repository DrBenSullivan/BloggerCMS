using BloggerCMS.Domain.Models;

namespace BloggerCMS.Domain.Repositories.Interfaces
{
    public interface IEntryRepository
    {
        Task<IEnumerable<BlogEntry>> GetRecentEntriesAsync(int count);
        Task<BlogEntry> GetByIdAsync(int id);
        Task AddAsync(BlogEntry entry);
    }
}



