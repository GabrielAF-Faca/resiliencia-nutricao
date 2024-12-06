using FluentValidation;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;
public class QuestionGroupUpdateDtoValidator : AbstractValidator<QuestionGroupUpdateDto>
{
    public QuestionGroupUpdateDtoValidator()
    {
        RuleFor(r => r.Id)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Id"));

        RuleFor(r => r.IdQuestionnaire)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Id do questionário"));

        RuleFor(r => r.Description)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Descrição do grupo de questões"))
            .MaximumLength(256)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Descrição do grupo de questões", 256));
    }
}
