using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyMicroservices.Shared.Services
{
    public interface IIdentityService
    {
        Guid UserId { get; }
        string UserName { get; }

        List<string> Roles { get; }
    }
}
