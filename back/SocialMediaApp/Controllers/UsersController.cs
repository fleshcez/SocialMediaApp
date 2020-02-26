using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Api.ViewModels;
using SocialMediaApp.Data.repositories.UserRepo;
using SocialMediaApp.Domain.Entities;

namespace SocialMediaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<UserModel[]>> GetUsers(bool withAddress = false)
        {
            try
            {
                var results = await _userRepository.GetAllUsersAsync(withAddress);

                return withAddress ? _mapper.Map<UserModelWithAddress[]>(results) : _mapper.Map<UserModel[]>(results);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id, bool withAddress = false)
        {
            try
            {
                var user = await _userRepository.GetUserAsync(id, withAddress);

                if (user == null)
                {
                    return NotFound();
                }

                return withAddress ? _mapper.Map<User, UserModelWithAddress>(user) : _mapper.Map<User, UserModel>(user);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
            }

        }

        // PUT: api/Users/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            //_context.Entry(user).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await UserExists(id)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserModelWithAddress user)
        {
            var usr = _mapper.Map<User>(user);
            _userRepository.Add(usr);
            await _userRepository.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, _mapper.Map<UserModelWithAddress>(user));
        }

        // DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<User>> DeleteUser(int id)
        //{
        //    var user = await _userRepository.GetUserAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _userRepository.Delete(user);
        //    await _userRepository.SaveChangesAsync();

        //    return user;
        //}

        private async Task<bool> UserExists(int id)
        {
            return (await _userRepository.GetUserAsync(id, false)) != null;
        }
    }
}
