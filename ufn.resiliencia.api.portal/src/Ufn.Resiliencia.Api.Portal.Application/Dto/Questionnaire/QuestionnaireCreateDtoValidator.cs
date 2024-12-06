using FluentValidation;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;
public class QuestionnaireCreateDtoValidator : AbstractValidator<QuestionnaireCreateDto>
{
    public QuestionnaireCreateDtoValidator()
    {
        RuleFor(r => r.IdRespondentGroup)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Id do Grupo"));

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
