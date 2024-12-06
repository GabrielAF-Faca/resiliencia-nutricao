using Microsoft.AspNetCore.Identity;

using Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Password;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.Shared;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Shared.Notifications;
using Ufn.Resiliencia.Api.Auth.WebApi.Domain.Entities.User;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.Password;

public class PasswordService : BaseService, IPasswordService
{

    private readonly UserManager<ApplicationUser> _userManager;

    public PasswordService(UserManager<ApplicationUser> userManager, NotificationContext notificationContext) : base(notificationContext)
    {
        _userManager = userManager;
    }

    public async Task ChangePasswordAsync(ChangePasswordDto dto)
    {
        ValidateDto(dto, new ChangePasswordDtoValidator());

        if (NotificationContext.HasNotifications)
        {
            return;
        }

        var identityUser = _userManager.Users.FirstOrDefault(user => user.Id == dto.UserId);
        if (identityUser == null)
        {
            NotificationContext.AddNotification(nameof(ApplicationErrorMessages.UserNotFound), ApplicationErrorMessages.UserNotFound);
            return;
        }

        var result = await _userManager.ChangePasswordAsync(identityUser, dto.ActualPassword, dto.NewPassword);
        if (!result.Succeeded)
        {
            if (result.Errors.First().Code == nameof(IdentityErrorDescriber.PasswordMismatch))
            {
                NotificationContext.AddNotification(nameof(ApplicationErrorMessages.IncorrectPassword), ApplicationErrorMessages.IncorrectPassword);
                return;
            }

            throw new Exception(result.Errors.First().Description);
        }
    }
}
