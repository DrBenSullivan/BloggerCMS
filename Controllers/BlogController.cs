using BloggerCMS.Domain.Models;
using BloggerCMS.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BloggerCMS.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Read(int id)
        {
            var repository = new BlogRepository();
            var entry = repository.GetEntry(id);
            return View(entry);
        }
    }
}
