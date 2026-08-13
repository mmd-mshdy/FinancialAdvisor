namespace FinAdvisor.Modules.Advisory.Domain.Insights
{
    public class PortfolioInsight
    {
        public Guid Id { get; private set; }

        public Guid PortfolioId { get; private set; }

        public InsightType Type { get; private set; }

        public string Title { get; private set; } = null!;

        public string Description { get; private set; } = null!;

        public InsightSeverity Severity { get; private set; }

        public DateTime GeneratedAt { get; private set; }
    }
}
