using System.Security.Claims;

namespace Learn.Authenticate.Shared.Extensions
{
    public static class AuthExtension
    {
        public const string UserExtentionId = "UserExtentionId";

        public static int GetUserId(this IEnumerable<Claim> claims)
        {
            var value = GetClaimValueByType(claims, ClaimTypes.NameIdentifier);
            return value != null ? int.Parse(value) : 0;
        }

        public static string GetUserName(this IEnumerable<Claim> claims)
        {
            return GetClaimValueByType(claims, ClaimTypes.Name);
        }

        public static Guid? GetUserExtentionId(this IEnumerable<Claim> claims)
        {
            var value = GetClaimValueByType(claims, UserExtentionId);
            return value != null ? Guid.Parse(value) : null;
        }

        public static bool IsAdmin(this IEnumerable<Claim> claims)
        {
            var value = GetClaimValueByType(claims, ClaimTypes.Role);

            if(value == null)
            {
                return false;
            }

            return value.ToUpper().Equals(RoleExtension.Admin.ToUpper());
        }

        public static bool IsStaff(this IEnumerable<Claim> claims)
        {
            var value = GetClaimValueByType(claims, ClaimTypes.Role);

            if (value == null)
            {
                return false;
            }

            return value.ToUpper().Equals(RoleExtension.Staff.ToUpper());
        }

        private static string GetClaimValueByType(IEnumerable<Claim> claims, string claimType)
        {
            if (claims == null || !claims.Any() || string.IsNullOrEmpty(claimType))
            {
                return null;
            }

            var claim = claims.FirstOrDefault(c => c.Type.Equals(claimType));
            if (claim == null)
            {
                return null;
            }

            return claim.Value;
        }
    }
}
