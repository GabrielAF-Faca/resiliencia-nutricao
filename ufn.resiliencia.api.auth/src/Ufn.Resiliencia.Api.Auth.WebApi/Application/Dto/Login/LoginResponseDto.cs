using TokenDomain = Ufn.Resiliencia.Api.Auth.WebApi.Domain.Entities.Token.Token;
using UserDataDomain = Ufn.Resiliencia.Api.Auth.WebApi.Domain.Entities.User.UserData;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Login;

public class LoginResponseDto
{
    public UserDataDomain User { get; set; }
    public TokenDomain Token { get; set; }
}
