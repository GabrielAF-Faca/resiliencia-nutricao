using Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Login;
public class LoginDto : BaseDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}