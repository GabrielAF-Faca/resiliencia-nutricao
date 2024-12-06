namespace Ufn.Resiliencia.Api.Auth.WebApi.Domain.Entities.User;

public class UserData
{
    public string Name { get; set; }
    public IEnumerable<string> Profiles { get; set; }
}
