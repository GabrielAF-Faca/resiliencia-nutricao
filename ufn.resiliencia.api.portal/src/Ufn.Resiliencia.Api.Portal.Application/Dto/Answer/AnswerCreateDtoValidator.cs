using FluentValidation;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Answer;
public class AnswerCreateDtoValidator : AbstractValidator<AnswerCreateDto>
{
    public AnswerCreateDtoValidator()
    {
        RuleFor(r => r.IdQuestion)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Id da questão"));

        RuleFor(r => r.QuestionOneAnswered)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Primeira questão"))
            .Must(r => r == false)
            .When(r => r.QuestionTwoAnswered == true || r.QuestionThreeAnswered == true )
            .WithMessage("Só é possível selecionar uma resposta");

        RuleFor(r => r.QuestionTwoAnswered)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Segunda questão"))
            .Must(r => r == false)
            .When(r => r.QuestionOneAnswered == true || r.QuestionThreeAnswered == true )
            .WithMessage("Só é possível selecionar uma resposta");

        RuleFor(r => r.QuestionThreeAnswered)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Terceira questão"))
            .Must(r => r == false)
            .When(r => r.QuestionOneAnswered == true || r.QuestionTwoAnswered == true )
            .WithMessage("Só é possível selecionar uma resposta");

        RuleFor(r => r.AdditionalQuestionAnswered)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Questão adicional"))
            .Must(r => r.Length > 0)
            .When(r => r.QuestionOneAnswered == true || r.QuestionTwoAnswered == true || r.QuestionThreeAnswered == true)
            .WithMessage("Só é possível selecionar uma resposta");
    }
}
