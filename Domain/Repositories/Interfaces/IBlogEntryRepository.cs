using BloggerCMS.Domain.Models;

namespace BloggerCMS.Domain.Repositories.Interfaces
{
    public interface IBlogEntryRepository
    {
        Task<BlogEntry> GetByIdAsync(int id);
    }
}



