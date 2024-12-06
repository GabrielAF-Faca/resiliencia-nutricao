using FluentValidation;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Login;
public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(user => user.Username)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.RequiredField, "Usuário"))
            .Length(6, 200)
            .WithMessage(string.Format(ApplicationValidationMessages.LengthBetween, "Usuário", 6, 200))
            .EmailAddress().WithMessage(string.Format(ApplicationValidationMessages.InvalidFieldValue, "Usuário"));

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.RequiredField, "Senha"))
            .MaximumLength(200)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Senha", 200));
    }
}