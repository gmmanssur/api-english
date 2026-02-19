using ApiEnglish.Domain.Entities;
using ApiEnglish.Domain.Interfaces;
using ApiEnglish.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace ApiEnglish.Infrastructure.Persistence.Repository
{
    public sealed class UserRepository(EpgDbContext context) : IUserRepository
    {
        private readonly EpgDbContext _context = context;

        private readonly List<User> _users = [];

        public async Task RegisterUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public User? GetUserById(Guid id)
        {
            return _users.FirstOrDefault(u => u.Sequencial == id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        
        public Task<bool> EmailExistsAsync(string email)
        {
            return _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}