using ApiEnglish.Domain.Entities;

namespace ApiEnglish.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task RegisterUserAsync(User user);
        User? GetUserById(Guid id);
        User? GetUserByUsername(string username);
        User? GetUserByEmail(string email);
        Task<bool> UsernameExistsAsync(string username);
        Task<bool> EmailExistsAsync(string email);
    }
}