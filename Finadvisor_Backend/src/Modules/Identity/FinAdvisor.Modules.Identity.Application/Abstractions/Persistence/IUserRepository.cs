using System;
using System.Collections.Generic;
using System.Text;
using FinAdvisor.Modules.Identity.Domain.Users;


namespace FinAdvisor.Modules.Identity.Application.Abstractions.Persistence
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id , CancellationToken cancellationToken = default);
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);
        void Add(User user);
        void Update(User user);
        void Remove(User user);
    }
}
