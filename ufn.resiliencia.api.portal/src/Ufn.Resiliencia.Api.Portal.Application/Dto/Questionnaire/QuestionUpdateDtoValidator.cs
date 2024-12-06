﻿using FluentValidation;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;
public class QuestionUpdateDtoValidator : AbstractValidator<QuestionUpdateDto>
{
    public QuestionUpdateDtoValidator()
    {
        RuleFor(r => r.Id)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Id da questão"));

        RuleFor(r => r.IdQuestionGroup)
            .NotNull()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Id do Grupo de Questões"));

        RuleFor(r => r.QuestionOrder)
            .GreaterThan(0)
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Ordem da questão"));

        RuleFor(r => r.QuestionDescription)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Descrição da questão"))
            .MaximumLength(500)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Descrição da questão", 500));

        RuleFor(r => r.FirstAnswer)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Primeira questão"))
            .MaximumLength(3)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Primeira questão", 3)); 

        RuleFor(r => r.SecondAnswer)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Segunda questão"))
            .MaximumLength(3)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Segunda questão", 3)); 

        RuleFor(r => r.ThirdAnswer)
            .MaximumLength(256)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Terceira questão", 30));

        RuleFor(r => r.AdditionalAnswer)
            .MaximumLength(256)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Questão adicional", 256));
    }
}
