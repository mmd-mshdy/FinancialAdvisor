namespace FinAdvisor.BuildingBlocks.Domain
{
    public interface IDomainEvent
    {
        public DateTime OccuredAt { get; }
    }
}
