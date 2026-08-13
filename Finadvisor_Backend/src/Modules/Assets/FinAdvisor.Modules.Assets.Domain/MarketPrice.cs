namespace FinAdvisor.Modules.Assets.Domain
{
    public class MarketPrice
    {
        public long Id { get; private set; }

        public Guid AssetId { get; private set; }

        public decimal Price { get; private set; }

        public DateTime Timestamp { get; private set; }

        private MarketPrice() { }
    }
}
