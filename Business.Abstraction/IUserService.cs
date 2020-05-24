using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;
using Microsoft.AspNetCore.Identity;

namespace Business.Abstraction
{
    public interface IUserService
    {
        Task<IdentityResult> Register(UserRegistrationModel model);
    }
}