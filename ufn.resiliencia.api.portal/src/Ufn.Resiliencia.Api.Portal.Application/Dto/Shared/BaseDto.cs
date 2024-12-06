using FluentValidation;
using System.Text.Json.Serialization;

using FluentValidation.Results;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Shared;

public abstract class BaseDto
{
    [JsonIgnore]
    internal bool Valid { get; private set; }
    [JsonIgnore]
    internal bool Invalid => !Valid;
    [JsonIgnore]
    internal ValidationResult ValidationResult { get; private set; }

    public bool Validate<TDto>(TDto dto, AbstractValidator<TDto> validator)
    {
        ValidationResult = validator.Validate(dto);
        return Valid = ValidationResult.IsValid;
    }
}
