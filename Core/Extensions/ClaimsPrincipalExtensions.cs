using System.Security.Claims;

namespace Core.Utilities.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string>? Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {

            List<string>? result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string>? ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {

            List<string>? a = claimsPrincipal?.Claims(ClaimTypes.Role);
            return a;
        }
    }
}
