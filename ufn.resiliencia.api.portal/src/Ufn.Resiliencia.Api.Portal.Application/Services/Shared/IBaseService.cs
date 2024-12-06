using FluentValidation;

using Ufn.Resiliencia.Api.Portal.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Portal.Application.Services.Shared;

public interface IBaseService
{
    void ValidateDto<TDto>(TDto dto, AbstractValidator<TDto> validator) where TDto : BaseDto;
}
