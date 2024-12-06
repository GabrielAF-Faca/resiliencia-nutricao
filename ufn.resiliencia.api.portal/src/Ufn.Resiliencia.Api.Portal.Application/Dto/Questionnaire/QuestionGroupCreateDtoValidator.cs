using FluentValidation;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;
public class QuestionGroupCreateDtoValidator : AbstractValidator<QuestionGroupCreateDto>
{
    public QuestionGroupCreateDtoValidator()
    {
        RuleFor(r => r.IdQuestionnaire)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Id do Questionário"));

        RuleFor(r => r.Description)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Descrição do grupo de questões"))
            .MaximumLength(256)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Descrição do grupo de questões", 256));
    }
}
