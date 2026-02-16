using MediatR;

namespace ApiEnglish.Application.DTOs.Auth
{
    public sealed record RegisterRequest(string Name, string Username, string Email, string Password);
}