using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyMicroservices.Shared.Services
{
    public interface IIdentityService
    {
        public Guid UserId { get; }
        public string UserName { get; }
    }
}
