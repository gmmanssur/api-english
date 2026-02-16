using ApiEnglish.Application.DTOs.Auth;
using MediatR;

namespace ApiEnglish.Application.CommandHandler.Auth
{
    public sealed record LoginCommand(string Email, string Password): IRequest<LoginResponse>;
}