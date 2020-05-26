using System.Security.Claims;
using System.Threading.Tasks;
using Business.Models;
using Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Business.Abstraction
{
    public interface IUserService
    {
        Task<IdentityResult> Register(UserRegistrationModel model);
        
        Task<SignInResult> Login(UserLoginModel model);

        Task<bool> IsEmailConfirmed(User model);

        Task<IdentityResult> ConfirmEmail(User user, string code);

        Task<Data.Entities.User> GetUserByClaims(ClaimsPrincipal claims);

        Task SignOut();
    }
}