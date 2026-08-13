
namespace FinAdvisor.Modules.Wallet.Domain.Accounts
{
    public class WalletAccount
    {
        public Guid Id { get; private set; }

        public Guid WalletId { get; private set; }

        public string Address { get; private set; } = null!;

        public BlockchainNetwork Network { get; private set; }

        private WalletAccount() { }
    }
}
