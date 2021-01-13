using System.Security.Claims;

namespace BlogIdentity
{
    public static class UserExtentions
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            if (user is not null && user.Identity is not null && user.Identity.IsAuthenticated)
            {
                var nameIdentifier = user.FindFirst(ClaimTypes.NameIdentifier);
                return (nameIdentifier?.Value ?? string.Empty);
            }
            return string.Empty;
        }
    }

}
