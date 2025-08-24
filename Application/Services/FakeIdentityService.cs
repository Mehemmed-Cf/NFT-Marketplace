using Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
namespace Application.Services
{
    public class FakeIdentityService : IIdentityService
    {
        public int? GetPrincipialId()
        {
            return 1;
        }
    }
}
