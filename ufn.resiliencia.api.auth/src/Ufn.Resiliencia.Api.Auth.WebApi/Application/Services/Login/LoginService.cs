using System.Net;

using Microsoft.AspNetCore.Identity;

using Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Login;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.Shared;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.Token;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Shared.Notifications;
using Ufn.Resiliencia.Api.Auth.WebApi.Domain.Entities.User;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.Login;
public class LoginService : BaseService, ILoginService
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenService _tokenService;

    public LoginService(SignInManager<ApplicationUser> signInManager, ITokenService tokenService, NotificationContext notificationContext) : base(notificationContext)
    {
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<LoginResponseDto?> PerformLoginAsync(LoginDto dto)
    {
        ValidateDto(dto, new LoginDtoValidator());

        if (NotificationContext.HasNotifications)
        {
            return null;
        }

        var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

        if (!result.Succeeded)
        {
            NotificationContext.AddNotification(nameof(ApplicationErrorMessages.LoginError), ApplicationErrorMessages.LoginError, (int)HttpStatusCode.Unauthorized);
            return default;
        }

        var identityUser = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

        if (identityUser == null)
        {
            NotificationContext.AddNotification(nameof(ApplicationErrorMessages.UserNotFound), ApplicationErrorMessages.UserNotFound);
            return default;
        }

        if (identityUser.IsBlocked)
        {
            NotificationContext.AddNotification(nameof(ApplicationErrorMessages.UserBlocked), ApplicationErrorMessages.UserBlocked, (int)HttpStatusCode.Forbidden);
            return default;
        }

        var roles = await _signInManager.UserManager.GetRolesAsync(identityUser);

        var token = _tokenService.GenerateToken(identityUser, roles);

        var loginResponse = new LoginResponseDto
        {
            Token = token,
            User = new UserData
            {
                Name = dto.Username,
                Profiles = roles
            }
        };

        return loginResponse;
    }
}
