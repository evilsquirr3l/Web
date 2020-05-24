using System.Security.Claims;
using System.Threading.Tasks;
using Business.Abstraction;
using Business.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
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
            
            var result =  await _userService.Register(model);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                
                return View(model);
            }
            
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            
            var claims =  await _userService.Login(model);

            if (claims == null)
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View();
            }

            await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                new ClaimsPrincipal(claims));
                
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}