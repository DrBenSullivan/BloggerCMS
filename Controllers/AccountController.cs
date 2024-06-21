using AutoMapper;
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
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var accounts = await _accountService.FetchAccountsAsync();
                return View(accounts);
            }
            catch (KeyNotFoundException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "An error occurred while getting the accounts from the database.";
                return View("Error");
            }
        }

        public async Task<IActionResult> View(int id)
        {
            try
            {
                var account = await _accountService.FetchAccountByIdAsync(id);
                return View(account);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
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
                return View("New", newAccount);
            }
            
            try
            {
                var account = await _accountService.SaveAccountAsync(newAccount);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Failed to add account: {ex.Message}";
                return View("Error");
            }

        }
    }
}
