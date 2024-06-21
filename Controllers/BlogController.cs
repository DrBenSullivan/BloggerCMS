using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BloggerCMS.Domain.ViewModels;
using AutoMapper;

namespace BloggerCMS.Controllers
{
    public class BlogController : Controller
    {
        #region Private Properties
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public BlogController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }
        #endregion

        public async Task<IActionResult> Index()
        {
            Dictionary<Account, List<Blog>> accountBlogsDictionary = await _blogService.FetchBlogsAsync();
            return View(accountBlogsDictionary);
        }

        public async Task<IActionResult> View(int id)
        {
            try
            {
                var blog = await _blogService.FetchBlogByIdAsync(id);
                return View(blog);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> New()
        {
            var accounts = await _blogService.FetchAccountsAsync();
            var model = new NewBlogViewModel(accounts);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNew(NewBlogViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("New");
            }

            var author = model.Accounts.FirstOrDefault(a => a.Id == model.AuthorId);
            var newBlog = _mapper.Map<Blog>(model);
            var response = await _blogService.SaveBlogAsync(newBlog);
            Console.WriteLine($"New blog {response.AuthorId}, {response.Title} {response.Description}");
            return RedirectToAction("New", "Entry");
        }
    }
}
