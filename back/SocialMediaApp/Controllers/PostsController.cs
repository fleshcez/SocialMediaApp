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

        [HttpPost]
        public async Task<ActionResult<PostModel>> PostPost(PostModel post)
        {
            var id = await _postRepository.GetUserIdAsync(post.userUserName);
            var pst = _mapper.Map<Post>(post);
            pst.UserId = id;
            _postRepository.Add(pst);
            await _postRepository.SaveChangesAsync();

            return _mapper.Map<Post, PostModel>(pst);
        }

        //DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PostModel>> DeletePost(int id)
        {
            var post = await _postRepository.GetPostAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _postRepository.Delete(post);
            await _postRepository.SaveChangesAsync();

            return _mapper.Map<PostModel>(post);
        }
    }
}
