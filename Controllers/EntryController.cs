using Microsoft.AspNetCore.Mvc;

namespace BloggerCMS.Controllers
{
    public class EntryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            return View();
        }
    }
}
