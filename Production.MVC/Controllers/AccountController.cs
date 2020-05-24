using System.Threading.Tasks;
using Business.Abstraction;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Production.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var message =  await _userService.Register(model);

            return Content(message);
            
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}