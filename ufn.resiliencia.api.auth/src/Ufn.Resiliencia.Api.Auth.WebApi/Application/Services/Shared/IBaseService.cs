using FluentValidation;

using Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.Shared;

public interface IBaseService
{
    void ValidateDto<TDto>(TDto dto, AbstractValidator<TDto> validator) where TDto : BaseDto;
}
