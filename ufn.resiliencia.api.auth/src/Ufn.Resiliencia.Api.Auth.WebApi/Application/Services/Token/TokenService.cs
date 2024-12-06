using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.IdentityModel.Tokens;

using Ufn.Resiliencia.Api.Auth.WebApi.Api.Config;
using Ufn.Resiliencia.Api.Auth.WebApi.Domain.Entities.User;

using TokenDomain = Ufn.Resiliencia.Api.Auth.WebApi.Domain.Entities.Token.Token;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.Token;
public class TokenService : ITokenService
{
    private readonly string? _secret;
    private readonly string? _issuer;
    private readonly string? _audience;

    public TokenService()
    {
        _secret = AppSettingsHelper.GetValue<string>("Auth:AudienceSecret");
        _issuer = AppSettingsHelper.GetValue<string>("Auth:Issuer");
        _audience = AppSettingsHelper.GetValue<string>("Auth:AudienceId");
    }

    public TokenDomain GenerateToken(ApplicationUser user, IList<string> roles)
    {
        var userClaims = new List<Claim>
        {
            new Claim("user_id", user.Id),
            new Claim("username", user.UserName)
        };

        foreach (var role in roles)
        {
            userClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(_secret!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var expirationTime = AppSettingsHelper.GetValue<int>("Auth:JwtTTL");

        var issuedUtc = DateTime.UtcNow;
        var expiresUtc = DateTime.UtcNow.AddHours(expirationTime);

        var jwtToken = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(userClaims),
            SigningCredentials = credentials,
            Issuer = _issuer,
            Audience = _audience,
            IssuedAt = issuedUtc,
            Expires = expiresUtc
        });

        var accessToken = tokenHandler.WriteToken(jwtToken);

        var expiresIn = (int)expiresUtc.Subtract(issuedUtc).TotalSeconds;

        var token = new TokenDomain
        {
            AccessToken = accessToken,
            ExpiresIn = expiresIn
        };

        return token;
    }
}
