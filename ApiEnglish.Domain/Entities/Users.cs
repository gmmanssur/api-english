namespace ApiEnglish.Domain.Entities
{
    public sealed record User
    {
        public Guid Sequencial { get; init; }
        public string? Name { get; init; }
        public string? Username { get; init; }
        public string? Email { get; init; }
        public string? PasswordHash { get; init; }
        public DateTime CreatedAt { get; init; }
        public bool Active { get; init; }
    }
}