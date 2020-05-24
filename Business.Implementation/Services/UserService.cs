using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstraction;
using Business.Models;
using Data.Abstraction;
using Data.Entities;

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

        public async Task<string> Register(UserRegistrationModel model)
        {
            var user = _mapper.Map<User>(model);

            var result = await _unit.UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var message = result.Errors.Aggregate("", (current, identityError) => current + (identityError.Code + " " + identityError.Description + "\n"));

                return message;
            }

            return "OK";
        }
    }
}