using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthNote.Infrastructure.Authentication
{
    internal static class ClaimsPrincipalExtensions
    {
        public static string GetIdentityId(this ClaimsPrincipal? principal)
        {
            return principal?.FindFirstValue("identityId") ?? throw new ApplicationException("User idenityt is unavailable");
        }
    }
}
