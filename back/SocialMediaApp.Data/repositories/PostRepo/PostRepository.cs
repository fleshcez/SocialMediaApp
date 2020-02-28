using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Domain.Entities;

namespace SocialMediaApp.Data.repositories.PostRepo
{
    public class PostRepository: IPostRepository
    {
        private readonly SoicalMediaContext _context;

        public PostRepository(SoicalMediaContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Post[]> GetAllPostsAsync(string username)
        {
            return await _context.Posts.Include(p => p.User).OrderByDescending(p => p.TimeStamp).ToArrayAsync();
        }

        public async Task<Post> GetPostAsync(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<Post> GetPostAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetUserIdAsync(string userName)
        {
            var user = await _context.Users.Where(u => u.UserName == userName).Select(u => new User{Id=u.Id}).FirstOrDefaultAsync();
            return user.Id;

        }

        public Task<User> GetUserAsync(string userName)
        {
            IQueryable<User> query = _context.Users;

            return query.FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
