using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Api.ViewModels;
using SocialMediaApp.Data.repositories.PostRepo;
using SocialMediaApp.Data.repositories.UserRepo;
using SocialMediaApp.Domain.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaApp.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PostsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public PostsController(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<PostModel[]>> GetPosts(string userName)
        {
            try
            {
                var posts= await _postRepository.GetAllPostsAsync(userName);

                return _mapper.Map<Post[], PostModel[]>(posts);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
            }
        }

        /*
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserModelWithAddress user)
        {
            var usr = _mapper.Map<User>(user);
            _userRepository.Add(usr);
            await _userRepository.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, _mapper.Map<UserModelWithAddress>(user));
        }
        */


        [HttpPost]
        public async Task<ActionResult<PostModel>> PostPost(PostModel post)
        {
            var user = await _postRepository.GetUserAsync(post.userUserName);
            var pst = _mapper.Map<Post>(post);
            pst.User = user;
            _postRepository.Add(pst);
            await _postRepository.SaveChangesAsync();

            return _mapper.Map<Post, PostModel>(pst);
        }
    }
}
