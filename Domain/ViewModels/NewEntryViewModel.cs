using BloggerCMS.Domain.DTO;
using BloggerCMS.Domain.FormModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BloggerCMS.Domain.ViewModels
{
    public class NewEntryViewModel
    {
        [BindProperty]
        public NewEntryFormModel NewEntryFormModel { get; set; }
        [BindNever]
        public IEnumerable<AccountDTO>? AccountsDTOList { get; set; }
        [BindNever]
        public Dictionary<int, IEnumerable<BlogDTO>>? AccountIdBlogDictionary { get; set; }


        #region Constructors
        public NewEntryViewModel() { }
        public NewEntryViewModel(IEnumerable<AccountDTO> accountsDTOList, Dictionary<int, IEnumerable<BlogDTO>> accountIdBlogDictionary)
        {
            AccountsDTOList = accountsDTOList;
            AccountIdBlogDictionary = accountIdBlogDictionary;
        }
        #endregion
    }
}
