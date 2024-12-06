using FluentValidation;

using Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Password;

public class ChangePasswordDtoValidator : AbstractValidator<ChangePasswordDto>
{
    public ChangePasswordDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId não encontrado");

        RuleFor(x => x.ActualPassword)
            .NotEmpty()
            .WithMessage("Senha atual é um campo obrigatório.")
            .MaximumLength(256)
            .WithMessage("Senha possui um tamanho máximo de 256 caracteres.");

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .WithMessage("Senha é um campo obrigatório.")
            .Matches(Constants.RegexPassword)
            .WithMessage("A senha não atende aos requisitos mínimos.")
            .MaximumLength(256)
            .WithMessage("Senha possui um tamanho máximo de 256 caracteres.")
            .NotEqual(x => x.ActualPassword)
            .WithMessage("Nova senha não pode ser igual a atual.");

        RuleFor(x => x.ConfirmNewPassword)
            .NotEmpty()
            .WithMessage("Confirmação de senha é um campo obrigatório.")
            .MaximumLength(256)
            .WithMessage("Confirmação de senha possui um tamanho máximo de 256 caracteres.")
            .Equal(x => x.NewPassword)
            .WithMessage("As senhas não são iguais");
    }
}
