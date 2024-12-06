using FluentValidation;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Answer;
public class AnswerUpdateDtoValidator : AbstractValidator<AnswerUpdateDto>
{
    public AnswerUpdateDtoValidator()
    {
        RuleFor(r => r.Id)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Id da resposta"));

        RuleFor(r => r.IdQuestion)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Id da questão"));

        RuleFor(r => r.QuestionOneAnswered)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Primeira questão"))
            .Equal(true)
            .When(r => r.QuestionTwoAnswered == false && r.QuestionThreeAnswered == false && r.AdditionalQuestionAnswered == false)
            .WithMessage("Só é possível selecionar uma resposta");

        RuleFor(r => r.QuestionTwoAnswered)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Segunda questão"))
            .Equal(true)
            .When(r => r.QuestionOneAnswered == false && r.QuestionThreeAnswered == false && r.AdditionalQuestionAnswered == false)
            .WithMessage("Só é possível selecionar uma resposta");

        RuleFor(r => r.QuestionThreeAnswered)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Terceira questão"))
            .Equal(true)
            .When(r => r.QuestionOneAnswered == false && r.QuestionTwoAnswered == false && r.AdditionalQuestionAnswered == false)
            .WithMessage("Só é possível selecionar uma resposta");

        RuleFor(r => r.AdditionalQuestionAnswered)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Questão adicional"))
            .Equal(true)
            .When(r => r.QuestionOneAnswered == false && r.QuestionTwoAnswered == false && r.QuestionThreeAnswered == false)
            .WithMessage("Só é possível selecionar uma resposta");
    }
}
