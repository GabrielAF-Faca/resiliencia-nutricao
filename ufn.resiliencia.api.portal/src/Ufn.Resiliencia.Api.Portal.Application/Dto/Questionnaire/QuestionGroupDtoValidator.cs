using FluentValidation;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;
public class QuestionGroupDtoValidator : AbstractValidator<QuestionGroupDto>
{
    public QuestionGroupDtoValidator()
    {
        RuleFor(r => r.Description)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Descrição do grupo de questões"))
            .MaximumLength(256)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Descrição do grupo de questões", 256));

        RuleFor(r => r.Questions)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Questões"));
    }
}
