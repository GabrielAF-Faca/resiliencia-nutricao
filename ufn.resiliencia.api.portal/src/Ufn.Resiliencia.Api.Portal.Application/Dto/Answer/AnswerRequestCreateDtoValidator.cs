using FluentValidation;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Answer;
public class AnswerRequestCreateDtoValidator : AbstractValidator<AnswerRequestCreateDto>
{
    public AnswerRequestCreateDtoValidator()
    {

        RuleFor(r => r.IdEstablishment)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Id do estabelecimento"));
        RuleFor(r => r.IdQuestionnaire)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Id do IdQuestionnaire"));

        RuleFor(r => r.UniqueCode)
            .MaximumLength(256)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Código da resposta", 256));

        RuleFor(r => r.Answers)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Respostas"));
    }
}
