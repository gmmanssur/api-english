namespace ApiEnglish.Application.DTOs.Auth
{
    public sealed record RegisterResponse
    {
        public string? Name { get; init; }
        public string? Username { get; init; }
        public string? Email { get; init; }
    }
}