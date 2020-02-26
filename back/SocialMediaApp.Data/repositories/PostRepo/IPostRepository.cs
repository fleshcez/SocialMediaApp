using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Domain.Entities;

namespace SocialMediaApp.Data.repositories.PostRepo
{
    public interface IPostRepository
    {
        // General 
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Camps
        Task<Post[]> GetAllPostsAsync(string username);
        Task<Post> GetPostAsync(int id);

        Task<Post> GetPostAsync(string userName);

        public Task<int> GetUserIdAsync(string userName);

        public Task<User> GetUserAsync(string userName);
    }
}
