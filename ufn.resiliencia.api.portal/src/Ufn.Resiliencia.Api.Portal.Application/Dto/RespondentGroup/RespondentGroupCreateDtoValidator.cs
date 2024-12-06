using FluentValidation;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.RespondentGroup;
public class RespondentGroupCreateDtoValidator : AbstractValidator<RespondentGroupCreateDto>
{
    public RespondentGroupCreateDtoValidator()
    {
        RuleFor(r => r.Description)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Descrição"))
            .MaximumLength(200)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Descrição", 200));
    }
}
