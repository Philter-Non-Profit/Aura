using Philter.Aura.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Philter.Aura.Data.Helpers;
public static class ClaimsPrincipalExtensions
{
    public static string UserId(this ClaimsPrincipal? user)
    {
        return user!.Claims.First(c => c.Type == nameof(AuraUser.AuraUserId)).Value;
    }

    public static ClaimsPrincipal GetNewClaimsPrincipal(this ClaimsPrincipal? user, AuraUser appUser)
    {
        ClaimsIdentity? microsoftIdentity = user!.Identities.ToList().Find(i => i.AuthenticationType == "AuthenticationTypes.Federation");

        ClaimsPrincipal newClaims = new();
        newClaims.GetAndApplyUserClaims(appUser);

        if (microsoftIdentity is not null)
        {
            newClaims.AddIdentity(microsoftIdentity);
        }

        return newClaims;
    }

    public static List<Claim> GetAndApplyUserClaims(this ClaimsPrincipal? user, AuraUser applicationUser)
    {
        List<Claim> claims = new()
        {
            new Claim(nameof(AuraUser.Name), applicationUser.Name),
            new Claim(nameof(AuraUser.Email), applicationUser.Email),
            new Claim(nameof(AuraUser.AuraUserId), applicationUser.AuraUserId.ToString()),
        };

        user?.AddIdentity(new(claims.ToList().AsEnumerable(), "AuraApp"));

        return claims;
    }
}