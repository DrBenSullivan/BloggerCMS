using BloggerCMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloggerCMS.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Read(int id)
        {
            var model = new BlogEntry(1, "Prof. Author", DateTime.Now, "A blog entry", "Welcome to my blog");
            return View(model);
        }
    }
}
