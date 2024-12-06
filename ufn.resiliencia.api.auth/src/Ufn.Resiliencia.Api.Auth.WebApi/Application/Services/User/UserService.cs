using Mapster;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.User;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.Shared;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Shared.Notifications;
using Ufn.Resiliencia.Api.Auth.WebApi.Domain.Entities.User;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.User;

public class UserService : BaseService, IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager, NotificationContext notificationContext) : base(notificationContext)
    {
        _userManager = userManager;
    }

    public async Task<string?> RegisterUser(RegisterUserDto dto)
    {
        ValidateDto(dto, new RegisterUserDtoValidator());

        if (NotificationContext.HasNotifications)
        {
            return null;
        }

        var user = await _userManager.FindByNameAsync(dto.Username);

        if (user != null)
        {
            NotificationContext.AddNotification(nameof(ApplicationErrorMessages.UserAlreadyRegistered), ApplicationErrorMessages.UserAlreadyRegistered);
            return null;
        }

        var identityUser = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = dto.Username,
            Email = dto.Username,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            IsBlocked = false,
            EmailConfirmed = true,
        };

        var result = await _userManager.CreateAsync(identityUser, dto.Password);

        if (!result.Succeeded)
        {
            NotificationContext.AddNotification(result.Errors.First().Code, result.Errors.First().Description);
            return null;
        }

        var addToRoleResult = await _userManager.AddToRoleAsync(identityUser, "admin");

        if (!addToRoleResult.Succeeded)
        {
            await _userManager.DeleteAsync(identityUser);
            NotificationContext.AddNotification(addToRoleResult.Errors.First().Code, addToRoleResult.Errors.First().Description);
            return default;
        }

        return dto.Username;
    }

    public async Task UpdateUser(UpdateUserDto dto)
    {
        ValidateDto(dto, new UpdateUserDtoValidator());

        if (NotificationContext.HasNotifications)
        {
            return;
        }

        var user = await _userManager.FindByIdAsync(dto.Id);

        if (user == null)
        {
            NotificationContext.AddNotification(nameof(ApplicationErrorMessages.UserNotFound), ApplicationErrorMessages.UserNotFound);
            return;
        }

        dto.Adapt(user);

        var updateResult = await _userManager.UpdateAsync(user);

        if (!updateResult.Succeeded)
        {
            NotificationContext.AddNotification(updateResult.Errors.First().Code, updateResult.Errors.First().Description);
            return;
        }

        var removePasswordResult = await _userManager.RemovePasswordAsync(user);

        if (!removePasswordResult.Succeeded)
        {
            NotificationContext.AddNotification(updateResult.Errors.First().Code, updateResult.Errors.First().Description);
            return;
        }

        var addPasswordResult = await _userManager.AddPasswordAsync(user, dto.Password);

        if (!addPasswordResult.Succeeded)
        {
            NotificationContext.AddNotification(updateResult.Errors.First().Code, updateResult.Errors.First().Description);
            return;
        }
    }

    public async Task BlockAndUnblockUserAsync(BlockAndUnblockUserDto dto)
    {
        ValidateDto(dto, new BlockAndUnblockUserDtoValidator());

        if (NotificationContext.HasNotifications)
        {
            return;
        }
        var user = await _userManager.FindByNameAsync(dto.Username);

        if (user == null)
        {
            NotificationContext.AddNotification(nameof(ApplicationErrorMessages.UserNotFound), ApplicationErrorMessages.UserNotFound);
            return;
        }

        user.IsBlocked = dto.IsBlocked;
        var blockResult = await _userManager.UpdateAsync(user);

        if (!blockResult.Succeeded)
        {
            NotificationContext.AddNotification(blockResult.Errors.First().Code, blockResult.Errors.First().Description);
            return;
        }
    }

    public async Task<IEnumerable<UserResponseDto>?> GetAll(string? id)
    {
        if (string.IsNullOrEmpty(id))
        {
            NotificationContext.AddNotification(nameof(ApplicationErrorMessages.UserNotFound), ApplicationErrorMessages.UserNotFound);
            return null;
        }
        var users = await _userManager.Users.Where(x => x.Id != id).ToListAsync();

        var response = users.Adapt<IEnumerable<UserResponseDto>>();

        return response;
    }

    public async Task<UserResponseDto> Get(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        var response = user.Adapt<UserResponseDto>();
        return response;
    }
}
