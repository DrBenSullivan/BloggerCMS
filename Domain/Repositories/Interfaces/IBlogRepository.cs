using BloggerCMS.Domain.Models;

namespace BloggerCMS.Domain.Repositories.Interfaces
{
    public interface IBlogRepository
    {
        BlogEntry GetEntry(int id);
    }
}



