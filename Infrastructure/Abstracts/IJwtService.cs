using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstracts
{
    public interface IJwtService
    {
        int? GetPrincipialId();

        string GenerateAccessToken(ClaimsPrincipal principal);
        string GenerateRefreshToken(string accessToken);
    }
}
