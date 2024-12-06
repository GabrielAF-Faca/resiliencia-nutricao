using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Api.Config;

public static class AuthenticationConfig
{
    public static void AddAuthenticationConfig(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        byte[] key = Convert.FromBase64String(AppSettingsHelper.GetValue<string>("Auth:AudienceSecret")!);

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = AppSettingsHelper.GetValue<string>("Auth:Issuer"),
                ValidAudience = AppSettingsHelper.GetValue<string>("Auth:AudienceId"),
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            };
        });
    }
}

