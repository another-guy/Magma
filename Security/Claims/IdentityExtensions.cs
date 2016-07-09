using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Magma.Security.Claims
{
    public static class IdentityExtensions
    {
        public static string GetNameId(this IIdentity identity)
        {
            return ((ClaimsIdentity)identity).Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}
