using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Api.ViewModels;
using SocialMediaApp.Data.repositories.UserRepo;
using SocialMediaApp.Domain.Entities;

namespace SocialMediaApp.Api.Controllers
{
    [Route("/auth/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UserModelWithAddress>> Post(UserModel user)
        {
            var foundUser = await _userRepository.GetUserAsync(user.UserName);

            if (foundUser != null && foundUser.Password == user.Password)
            {
                return _mapper.Map<UserModelWithAddress>(foundUser);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<UserModelWithAddress>> Post(UserModelWithAddress newUser)
        {
            var foundUser = await _userRepository.GetUserAsync(newUser.UserName);

            if (foundUser != null)
            {
                return BadRequest("User name already exists");
            }

            var usr = _mapper.Map<User>(newUser);
            _userRepository.Add(usr);
            await _userRepository.SaveChangesAsync();

            return _mapper.Map<UserModelWithAddress>(usr);
        }
    }
}
