using Microsoft.AspNetCore.Identity;

using Ufn.Resiliencia.Api.Auth.WebApi.Domain.Entities.User;
using Ufn.Resiliencia.Api.Auth.WebApi.Infra.Data.MySql;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Api.Config;

public static class IdentityConfig
{
    public static void AddIdentityConfig(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole<string>>(options =>
        {
            options.SignIn.RequireConfirmedEmail = false;
        })
        .AddEntityFrameworkStores<MySqlContext>()
        .AddDefaultTokenProviders();
    }
}
