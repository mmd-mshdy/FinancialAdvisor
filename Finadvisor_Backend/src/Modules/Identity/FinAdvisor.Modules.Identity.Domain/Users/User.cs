namespace FinAdvisor.Modules.Identity.Domain.Users
{
    public class User
    {
        public Guid Id { get; private set; }

        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;

        public string? Name { get; private set; }
        public string? FamilyName { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime LastLoginAt { get; private set; }
        private User() { }
        public User(string email, string passwordHash)
        {
            Id = Guid.NewGuid();
            Email = email;
            PasswordHash = passwordHash;
            CreatedAt = DateTime.Now;
        }


    }
}
