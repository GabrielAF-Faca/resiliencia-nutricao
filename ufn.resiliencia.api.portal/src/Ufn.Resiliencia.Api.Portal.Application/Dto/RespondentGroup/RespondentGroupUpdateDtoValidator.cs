using FluentValidation;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.RespondentGroup;
public class RespondentGroupUpdateDtoValidator : AbstractValidator<RespondentGroupUpdateDto>
{
    public RespondentGroupUpdateDtoValidator()
    {
        RuleFor(r => r.Id)
            .GreaterThan(0)
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Id"));
        RuleFor(r => r.Description)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Descrição"));
    }
}
