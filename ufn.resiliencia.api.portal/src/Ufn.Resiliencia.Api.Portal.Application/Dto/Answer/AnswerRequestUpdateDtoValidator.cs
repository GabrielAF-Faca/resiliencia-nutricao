using FluentValidation;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Answer;
public class AnswerRequestUpdateDtoValidator : AbstractValidator<AnswerRequestUpdateDto>
{
    public AnswerRequestUpdateDtoValidator()
    {

        RuleFor(r => r.IdEstablishment)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Id do estabelecimento"));
        RuleFor(r => r.IdQuestionnaire)
          .NotNull()
          .WithMessage(string.Format(ApplicationValidationMessages.Required, "Id do IdQuestionnaire"));


        RuleFor(r => r.UniqueCode)
            .NotNull()
            .MaximumLength(256)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Código da resposta", 256));

        RuleFor(r => r.Answers)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Respostas"));
    }
}
