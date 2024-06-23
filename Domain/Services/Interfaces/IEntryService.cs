using BloggerCMS.Domain.DTO;
using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.ViewModels;

namespace BloggerCMS.Domain.Services.Interfaces
{
    public interface IEntryService
    {
        public Task<IEnumerable<BlogEntry>> FetchRecentEntriesAsync(int count);
        public Task<BlogEntry> FetchPostByIdAsync(int id);
        public Task<NewEntryViewModel> FetchNewEntryVMAsync();
        public Task<BlogEntry> SaveEntryAsync(BlogEntry entry);

	}
}
