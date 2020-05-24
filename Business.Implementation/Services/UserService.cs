using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstraction;
using Business.Models;
using Data.Abstraction;
using Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Business.Implementation.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUnitOfWork unit)
        {
            _mapper = mapper;
            _unit = unit;
        }

        public async Task<IdentityResult> Register(UserRegistrationModel model)
        {
            var user = _mapper.Map<User>(model);
            var result = await _unit.UserManager.CreateAsync(user, model.Password);

            return result;
        }

        public async Task<ClaimsIdentity> Login(UserLoginModel model)
        {
            var user = await _unit.UserManager.FindByEmailAsync(model.Email);

            var result = await _unit.UserManager.CheckPasswordAsync(user, model.Password);

            if (user != null && await _unit.UserManager.CheckPasswordAsync(user, model.Password))
            {
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                return identity;
            }

            return null;
        }
    }
}