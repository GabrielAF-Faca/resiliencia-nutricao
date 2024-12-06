using Microsoft.AspNetCore.Mvc;

namespace Ufn.Resiliencia.Api.Portal.Api.Extensions;

public static class SecurityExtensions
{
    public static string? GetUserIdClaim(this ControllerBase controller)
    {
        if (controller.User == null) return null;

        var userClaims = controller.User.Claims.ToList();
        var userIdClaim = userClaims?.FirstOrDefault(a => a.Type == "user_id");

        return userIdClaim == null ? null : userIdClaim.Value;
    }
}