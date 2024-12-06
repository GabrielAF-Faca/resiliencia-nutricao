using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Ufn.Resiliencia.Api.Portal.Api.Config;

public static class AuthenticationConfig
{
    public static void AddAuthenticationConfig(this IServiceCollection services, IConfiguration config)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        byte[] key = Convert.FromBase64String(config.GetValue<string>("Auth:AudienceSecret")!);

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = config.GetValue<string>("Auth:Issuer"),
                ValidAudience = config.GetValue<string>("Auth:AudienceId"),
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            };
        });
    }
}

