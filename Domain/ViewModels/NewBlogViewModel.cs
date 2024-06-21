using System.ComponentModel.DataAnnotations;
using BloggerCMS.Domain.Models;

namespace BloggerCMS.Domain.ViewModels
{
    public class NewBlogViewModel
    {
        #region Properties
        // List to display accounts to assign blog to.
        public List<Account> Accounts { get; set; } = [];

        // Data collection
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;

        #endregion


        #region Constructors
        public NewBlogViewModel() { }

        public NewBlogViewModel(List<Account> accounts)
        {
            Accounts = accounts;

        }
        #endregion

    }
}
