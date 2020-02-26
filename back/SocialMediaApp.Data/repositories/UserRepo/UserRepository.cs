using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Data.contexts;
using SocialMediaApp.Domain.Entities;

namespace SocialMediaApp.Data.repositories.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        private IQueryable<User> _includeAddress(IQueryable<User> query)
        {
            return query.Include(u => u.Address);
        }

        public async Task<User[]> GetAllUsersAsync(bool withAddress)
        {
            IQueryable<User> query = _context.Users;

            if (withAddress)
            {
                query = _includeAddress(query);
            }

            return await query.ToArrayAsync();
        }

        public async Task<User> GetUserAsync(int id, bool withAddress = false)
        {
            IQueryable<User> query = _context.Users;

            if (withAddress)
            {
                query = _includeAddress(query);
            }

            return await query.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserAsync(string userName)
        {
            IQueryable<User> query = _context.Users;

            return await query.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
