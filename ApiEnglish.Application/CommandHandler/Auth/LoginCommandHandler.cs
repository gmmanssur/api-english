using ApiEnglish.Application.DTOs.Auth;
using ApiEnglish.Application.Interfaces;
using ApiEnglish.Domain.Entities;
using ApiEnglish.Domain.Interfaces;
using MediatR;

namespace ApiEnglish.Application.CommandHandler.Auth;

public sealed class LoginCommandHandler(IUserRepository userRepository,
        IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator) 
    : IRequestHandler<LoginCommand, LoginResponse>
{

    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

    public async Task<LoginResponse> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            User? user = await _userRepository.GetUserByEmailAsync(request.Email);

            if (user is null
                || string.IsNullOrEmpty(user.PasswordHash)
                || !_passwordHasher.Verify(request.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            string token = _jwtTokenGenerator.GenerateToken(user);

            return new LoginResponse
            {
                AccessToken = token,
                Name = user.Name,
                Email = user.Email,
            };
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new UnauthorizedAccessException(ex.Message);
        }
    }
}
