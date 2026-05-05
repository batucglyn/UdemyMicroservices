using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyMicroservices.Shared.Services
{
    public class IdentityServiceMock : IIdentityService
    {
        public Guid UserId => Guid.Parse("81b6cd88-b9cc-4424-ae8c-7fcb9016d934");

        public string UserName => "MockUser";
    }
}
