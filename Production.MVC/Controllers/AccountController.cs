using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Abstraction;
using Business.Models;
using Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Production.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public AccountController(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
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

            var code = await _emailService.GenerateEmailConfirmationTokenAsync(model);
            
            var callbackUrl = Url.Action(
                "ConfirmEmail",
                "Account",
                new { userId = GetCurrentUser().Id, code = code },
                protocol: HttpContext.Request.Scheme);
            
            await _emailService.SendEmailAsync(model.Email, "Confirm email", $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userService.Login(model);
            
            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string code)
        {
            var user = await GetCurrentUser();
            var result = await _userService.ConfirmEmail(user, code);

            if (result.Succeeded)
            {
                RedirectToLocal(null);
            }
            ModelState.AddModelError("", result.Errors.ToString());

            return View("Error");
        }

        private async Task<User> GetCurrentUser()
        {
            return await _userService.GetUserByClaims(HttpContext.User);
        }
        
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOut()
        {
            await _userService.SignOut();
 
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}