using ApiEnglish.Application.DTOs.Auth;
using ApiEnglish.Application.Interfaces;
using ApiEnglish.Domain.Entities;
using ApiEnglish.Domain.Interfaces;
using MediatR;

namespace ApiEnglish.Application.CommandHandler.Auth;

public sealed class RegisterCommandHandler(IUserRepository userRepository,
        IPasswordHasher passwordHasher) 
    : IRequestHandler<RegisterCommand, RegisterResponse>
{

    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public async Task<RegisterResponse> Handle(
        RegisterCommand request,
        CancellationToken cancellationToken)
    {
        string hashedPassword = _passwordHasher.Hash(request.Password);

        User user = new()
        {
            Name = request.Name,
            Username = request.Username,
            Email = request.Email,
            PasswordHash = hashedPassword,
            CreatedAt = DateTime.UtcNow,
            Active = true
        };

        await _userRepository.RegisterUserAsync(user);
        
        return new RegisterResponse { 
            Name = user.Name,
            Username = user.Username,
            Email = user.Email
        };
    }
}
