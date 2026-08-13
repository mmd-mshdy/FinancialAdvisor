
namespace FinAdvisor.Modules.Wallet.Domain.Wallets
{
    public class Wallet
    {
        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }

        public string Name { get; private set; } = null!;

        public WalletType Type { get; private set; }

        public DateTime CreatedAt { get; private set; }

        private readonly List<WalletAccount> _accounts = new();

        public IReadOnlyCollection<WalletAccount> Accounts => _accounts;

        private Wallet() { }
    }
}
