namespace ApiEnglish.Application.DTOs.Auth
{
    public sealed record RegisterRequest(string Name, string Email, string Password, string ConfirmPassword);
}