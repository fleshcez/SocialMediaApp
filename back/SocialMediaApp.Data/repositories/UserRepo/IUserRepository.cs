using System.Threading.Tasks;
using SocialMediaApp.Domain.Entities;

namespace SocialMediaApp.Data.repositories.UserRepo
{
    public interface IUserRepository
    {
        // General 
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Camps
        Task<User[]> GetAllUsersAsync(bool withAddress);
        Task<User> GetUserAsync(int id, bool withAddress = false);

        Task<User> GetUserAsync(string userName);
    }
}
