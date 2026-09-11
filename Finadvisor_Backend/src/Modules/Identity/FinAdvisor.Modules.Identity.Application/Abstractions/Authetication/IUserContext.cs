using System;
using System.Collections.Generic;
using System.Text;

namespace FinAdvisor.Modules.Identity.Application.Abstractions.Authetication
{
    public interface IUserContext
    {
        Guid UserId { get; }

        bool IsAuthenticated { get; }
    }
}
