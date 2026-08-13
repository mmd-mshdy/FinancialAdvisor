namespace FinAdvisor.Modules.Advisory.Domain.Profiles
{
    public class FinancialProfile
    {
        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }

        public RiskTolerance RiskTolerance { get; private set; }

        public InvestmentHorizon InvestmentHorizon { get; private set; }

        public decimal? TargetReturn { get; private set; }
    }
}
