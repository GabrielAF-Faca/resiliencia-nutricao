namespace Ufn.Resiliencia.Api.Auth.WebApi.Domain.Entities.Token;

public class Token
{
    public string AccessToken { get; set; }
    public int ExpiresIn { get; set; }
}
