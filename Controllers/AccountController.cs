using BloggerCMS.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloggerCMS.Controllers
{
    public class AccountController : Controller
    {
        #region Private Properties
        private readonly IAccountService _accountService;
        #endregion

        #region Constructor
        public AccountController(IAccountService account) => _accountService = account;
        #endregion

        public async Task<IActionResult> Index()
        {
            try
            {
                var accounts = await _accountService.ListAccountsAsync();
                return View(accounts); // Pass the actual data to the view
            }
            catch (KeyNotFoundException ex)
            {
                // Handle the case where no accounts are found.
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
            catch (Exception)
            {
                // Handle any other exceptions.
                ViewBag.ErrorMessage = "An error occurred while retrieving accounts.";
                return View("Error");
            }
        }
    }
}
