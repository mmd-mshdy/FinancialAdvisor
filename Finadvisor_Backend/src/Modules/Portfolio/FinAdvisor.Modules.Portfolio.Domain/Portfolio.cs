namespace FinAdvisor.Modules.Portfolio.Domain
{
    public class Portfolio
    {
        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }

        public string Name { get; private set; } = null!;

        public DateTime CreatedAt { get; private set; }

        private readonly List<PortfolioAsset> _assets = new();

        public IReadOnlyCollection<PortfolioAsset> Assets => _assets;

        private Portfolio() { }
    }
}
