namespace FinAdvisor.Modules.Wallet.Domain.Transactions
{
    public class Transaction
    {
        public Guid Id { get; private set; }

        public Guid WalletId { get; private set; }
        public Guid AssetId { get; private set; }

        public TransactionType Type { get; private set; }

        public decimal Quantity { get; private set; }

        public decimal? PricePerUnit { get; private set; }

        public decimal? Fee { get; private set; }

        public string? TransactionHash { get; private set; }

        public DateTime Timestamp { get; private set; }
    }
}
