using FluentValidation;

using Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Shared;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Shared.Notifications;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.Shared;

public abstract class BaseService : IBaseService
{
    internal readonly NotificationContext NotificationContext;

    protected BaseService(NotificationContext notificationContext)
    {
        NotificationContext = notificationContext;
    }

    public void ValidateDto<TDto>(TDto dto, AbstractValidator<TDto> validator) where TDto : BaseDto
    {
        if (dto == null)
        {
            NotificationContext.AddNotification("BodyError", "Corpo da requisição inválido");
            return;
        }

        dto!.Validate(dto, validator);

        if (dto.Invalid)
        {
            NotificationContext.AddNotifications(dto.ValidationResult);
        }
    }
}