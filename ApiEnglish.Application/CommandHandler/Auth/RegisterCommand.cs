using ApiEnglish.Application.DTOs.Auth;
using MediatR;

namespace ApiEnglish.Application.CommandHandler.Auth
{
    public sealed record RegisterCommand(string Name, string Email, string Password, string ConfirmPassword): IRequest<RegisterResponse>;
}