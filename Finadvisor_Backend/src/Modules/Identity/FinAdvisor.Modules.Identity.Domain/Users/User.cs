using FinAdvisor.BuildingBlocks.Domain;
using FinAdvisor.Modules.Identity.Domain.Users.Events;
namespace FinAdvisor.Modules.Identity.Domain.Users
{
    public class User : AggregateRoot
    {

        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;

        public string? Name { get; private set; }
        public string? FirstName { get; private set; }
        public string? FamilyName { get; private set; }

        public UserRole Role { get; private set; }
        public UserStatus Status { get; private set; }

        public DateTime CreatedAtUtc { get; private set; }
        public DateTime? UpdatedAtUtc { get; private set; }
        public DateTime LastLoginAt { get; private set; }
        private User(Guid id) : base(id) { }
        public User(Guid id, string firstName, string lastName, string email, string passwordHash, UserRole role) : base (id)
        {
            Id = id;
            FirstName = firstName ?? string.Empty;
            lastName = lastName ?? string.Empty;
            Email = email;
            PasswordHash = passwordHash;
            CreatedAtUtc = DateTime.UtcNow;
            Role = role;
            Status = UserStatus.Active;
        }
        public static User Create(
        string email,
        string firstName,
        string lastName,
        string passwordHash)
        {
            var user = new User(
                Guid.NewGuid(),
                email.Trim().ToLowerInvariant(),
                firstName.Trim(),
                lastName.Trim(),
                passwordHash,
                UserRole.User);

            user.RaiseDomainEvent(
                new UserRegisteredDomainEvent(
                    user.Id,
                    user.Email));

            return user;
        }
    }

    }
