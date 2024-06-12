using BloggerCMS.Domain.Repositories.Interfaces;
using BloggerCMS.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BloggerCMS.Controllers
{
    public class BlogController : Controller
    {
        #region Private Properties
        private readonly IBlogEntryRepository _blogEntryRepository;
        #endregion

        #region Constructor
        public BlogController(IBlogEntryRepository blogEntryRepository)
        {
            _blogEntryRepository = blogEntryRepository;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Entries(int id = 1)
        {
            var blogEntry = await _blogEntryRepository.GetByIdAsync(id);

            if (blogEntry != null)
            {
                return View(blogEntry);
            }
            
            return Index();
        }
    }
}
