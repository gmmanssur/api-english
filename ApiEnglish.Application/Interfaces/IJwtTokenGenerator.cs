using ApiEnglish.Domain.Entities;

namespace ApiEnglish.Application.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
