using AutoMapper;
using BloggerCMS.Domain.DTO;
using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.Repositories.Interfaces;
using BloggerCMS.Domain.Services.Interfaces;
using BloggerCMS.Domain.ViewModels;

namespace BloggerCMS.Services
{
    public class EntryService(
        IEntryRepository entryRepository,
        IBlogService blogService,
        IMapper mapper,
        IAccountService accountService) : IEntryService
    {
        #region private properties
        private readonly IEntryRepository _entryRepository = entryRepository;
        private readonly IBlogService _blogService = blogService;
        private readonly IMapper _mapper = mapper;
        private readonly IAccountService _accountService = accountService;
        #endregion


        public async Task<IEnumerable<BlogEntry>> FetchRecentEntriesAsync(int count)
        {
            return await _entryRepository
                .GetRecentEntriesAsync(count)
                .ConfigureAwait(false);
        }

        public async Task<BlogEntry> FetchPostByIdAsync(int id)
        {
            return await _entryRepository
                .GetByIdAsync(id)
                .ConfigureAwait(false);
        }

        public async Task<NewEntryViewModel> FetchNewEntryVMAsync()
        {
            var accountsList = await _accountService
                    .FetchAccountsAsync()
                    .ConfigureAwait(false);
            var accountsDTOList = new List<AccountDTO>();
            foreach (var account in accountsList)
            {
                accountsDTOList.Add(_mapper.Map<AccountDTO>(account));
            }

            var accountBlogsDictionary = await _blogService
                    .FetchBlogsAsync()
                    .ConfigureAwait(false);
            var accountIdBlogsDTODictionary = new Dictionary<int, IEnumerable<BlogDTO>>();
            foreach (var kvp in accountBlogsDictionary)
            {
                var blogDTOs = new List<BlogDTO>();
                foreach (var blog in kvp.Value)
                {
                    var blogDTO = _mapper.Map<BlogDTO>(blog);
                    blogDTOs.Add(blogDTO);
                }
                accountIdBlogsDTODictionary.Add(kvp.Key.Id, blogDTOs);
            }

            return new NewEntryViewModel(accountsDTOList, accountIdBlogsDTODictionary);
        }

        public async Task<BlogEntry> SaveEntryAsync(BlogEntry entry)
        {
            await _entryRepository
                .AddAsync(entry)
                .ConfigureAwait(false);
            return entry;
        }
    }
}
