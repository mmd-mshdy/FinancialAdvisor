using System;
using System.Collections.Generic;
using System.Text;

namespace FinAdvisor.BuildingBlocks.Domain
{
    public sealed class DomainException(string message) : Exception(message);
}
