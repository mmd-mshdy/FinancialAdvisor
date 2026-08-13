namespace FinAdvisor.Modules.Predictions.Domain
{
    public class MarketPrediction
    {
        public Guid Id { get; private set; }

        public Guid AssetId { get; private set; }

        public PredictionDirection Direction { get; private set; }

        public decimal Confidence { get; private set; }

        public PredictionHorizon Horizon { get; private set; }

        public string ModelVersion { get; private set; } = null!;

        public DateTime GeneratedAt { get; private set; }

        public DateTime ValidUntil { get; private set; }
    }
}
