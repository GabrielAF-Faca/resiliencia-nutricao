using FluentValidation;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;
public class QuestionnaireUpdateDtoValidator : AbstractValidator<QuestionnaireUpdateDto>
{
    public QuestionnaireUpdateDtoValidator()
    {
        RuleFor(r => r.Id)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Id"));

        RuleFor(r => r.IdRespondentGroup)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Id"));

        RuleFor(r => r.Description)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Descrição do questionário"))
            .MaximumLength(256)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Descrição do questionário", 256));

        RuleFor(r => r.QuestionGroups)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Grupo de questões"));
    }
}
