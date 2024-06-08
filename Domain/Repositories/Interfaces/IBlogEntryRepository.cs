using BloggerCMS.Domain.Models;

namespace BloggerCMS.Domain.Repositories.Interfaces
{
    public interface IBlogEntryRepository
    {
        BlogEntry getEntry(int id);
    }
}
