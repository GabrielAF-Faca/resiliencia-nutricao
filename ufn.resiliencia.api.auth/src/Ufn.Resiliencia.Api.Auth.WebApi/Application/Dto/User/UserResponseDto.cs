namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.User;

public class UserResponseDto
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsBlocked { get; set; }
}
