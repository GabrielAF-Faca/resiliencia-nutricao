using Microsoft.AspNetCore.Identity;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Domain.Entities.User;
public class ApplicationUser : IdentityUser<string>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsBlocked { get; set; }
}
