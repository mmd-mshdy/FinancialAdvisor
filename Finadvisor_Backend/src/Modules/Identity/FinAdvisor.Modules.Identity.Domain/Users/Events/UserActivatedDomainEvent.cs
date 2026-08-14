using FinAdvisor.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinAdvisor.Modules.Identity.Domain.Users.Events
{
    public sealed record UserActivatedDomainEvent(Guid userId) : IDomainEvent
    {

        public DateTime OccuredAt { get; } = DateTime.Now;
    }
}

