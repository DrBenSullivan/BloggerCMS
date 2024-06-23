using AutoMapper;
using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.Services.Interfaces;
using BloggerCMS.Domain.FormModels;
using BloggerCMS.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BloggerCMS.Controllers
{
    public class EntryController : Controller
    {
        #region private properties
        private readonly IEntryService _entryService;
        private readonly IMapper _mapper;
        #endregion

        #region constructors
        public EntryController(IEntryService entryService, IMapper mapper)
        {
            _entryService = entryService;
            _mapper = mapper;
        }
        #endregion

        public async Task<IActionResult> Index(int? postsPerPage)
        {
            int count = postsPerPage != null
                ? postsPerPage.Value
                : 10;
            
            var blogPosts = await _entryService
                .FetchRecentEntriesAsync(count)
                .ConfigureAwait(false);

            return View(blogPosts);
        }

        #region '/Entry/View'
        [HttpGet("/Entry/View/{id}")]
        public async Task<IActionResult> View(int id)
        {
            var blogPost = await _entryService
                .FetchPostByIdAsync(id)
                .ConfigureAwait(false);

            return View(blogPost);
        }

        [HttpGet("/Entry/View")]
        public IActionResult View(BlogEntry entry) => View(entry);
        #endregion

        #region '/Entry/New'
        [HttpGet]
        public async Task<IActionResult> New()
        {
            NewEntryViewModel vm = await _entryService
                .FetchNewEntryVMAsync()
                .ConfigureAwait(false);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(NewEntryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("New");
            }

            try
            {
                var formModel = vm.NewEntryFormModel;
                var newEntry = _mapper.Map<BlogEntry>(formModel);
                var blogEntry = await _entryService
                    .SaveEntryAsync(newEntry)
                    .ConfigureAwait(false);
                return RedirectToAction("Home", "Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Failed to add entry to database: {ex.Message}";
                return View("Error");
            }
        }
        #endregion
    }
}
