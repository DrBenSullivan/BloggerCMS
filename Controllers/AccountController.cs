using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BloggerCMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

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

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(Account newAccount)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is invalid"); 
                // If ModelState is not valid, return to the New view with the newAccount object
                return View("New", newAccount);
            }
            
            try
            {
                // Add the new account
                var account = await _accountService.AddAccountAsync(newAccount);

                // Redirect to the Index action
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Handle specific exceptions if needed
                ViewBag.ErrorMessage = $"Failed to add account: {ex.Message}";
                return View("Error");
            }

        }
    }
}
