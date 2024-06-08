using System.Diagnostics;
using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloggerCMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBlogEntryRepository _blogEntryRepository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Blog(int id)
        {
            var model = new BlogEntry(1, "Prof. Author", DateTime.Now, "A blog entry", "Welcome to my blog");
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
