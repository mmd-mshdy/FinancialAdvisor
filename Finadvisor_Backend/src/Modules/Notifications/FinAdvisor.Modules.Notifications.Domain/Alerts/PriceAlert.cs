namespace FinAdvisor.Modules.Notifications.Domain.Alerts
{
    public class PriceAlert
    {
        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }
        public Guid AssetId { get; private set; }

        public decimal TargetPrice { get; private set; }

        public AlertCondition Condition { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime CreatedAt { get; private set; }
    }
}
