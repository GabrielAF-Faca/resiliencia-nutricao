using Microsoft.AspNetCore.Mvc;

using Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.Login;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.Password;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.Token;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.User;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Shared.Notifications;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Api.Config;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        #region Notification
        services.AddScoped<NotificationContext>();
        #endregion

        #region Services
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<IUserService, UserService>();
        #endregion
    }
}


