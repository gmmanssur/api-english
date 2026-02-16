namespace ApiEnglish.Application.DTOs.Auth
{
    public sealed record LoginResponse
    {
        public string? Name { get; init; }
        public string? Email { get; init; }
        public string? AccessToken { get; init; }
    }
}