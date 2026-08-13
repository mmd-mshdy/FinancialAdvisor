namespace FinAdvisor.Modules.Portfolio.Domain
{
    public class PortfolioAsset
    {
        public Guid Id { get; private set; }

        public Guid PortfolioId { get; private set; }

        public Guid AssetId { get; private set; }

        public decimal Quantity { get; private set; }

        public decimal AveragePurchasePrice { get; private set; }
    }
}