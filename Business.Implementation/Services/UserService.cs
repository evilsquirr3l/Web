using System;
using System.Collections.Generic;
using System.Linq;
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

            // if (!result.Succeeded)
            // {
            //     return result.Errors.ToDictionary(error => error.Code, error => error.Description);
            // }

            return result;
        }
    }
}