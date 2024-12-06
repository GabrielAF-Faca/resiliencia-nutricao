using Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.User;

public class RegisterUserDto : BaseDto
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}