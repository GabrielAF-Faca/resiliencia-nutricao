using Ufn.Resiliencia.Api.Auth.WebApi.Domain.Entities.User;

using TokenDomain = Ufn.Resiliencia.Api.Auth.WebApi.Domain.Entities.Token.Token;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.Token;
public interface ITokenService
{
    TokenDomain GenerateToken(ApplicationUser user, IList<string> roles);
}
