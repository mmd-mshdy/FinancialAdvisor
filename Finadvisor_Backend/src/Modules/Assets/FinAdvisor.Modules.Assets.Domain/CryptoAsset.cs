namespace FinAdvisor.Modules.Assets.Domain
{
    public class CryptoAsset
    {
        public Guid Id { get; private set; }

        public string Symbol { get; private set; } = null!;
        public string Name { get; private set; } = null!;

        public string? ExternalId { get; private set; }

        public bool IsActive { get; private set; }

        private CryptoAsset() { }
    }
}
