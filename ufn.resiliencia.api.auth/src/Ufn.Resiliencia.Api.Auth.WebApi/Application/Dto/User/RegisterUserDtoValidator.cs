using FluentValidation;

using Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.User;

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Usuário é um campo obrigatório.")
            .MaximumLength(256)
            .WithMessage("Usuário possui um tamanho máximo de 256 caracteres.")
            .EmailAddress()
            .WithMessage("E-mail informado é inválido.")
            .WithErrorCode("Username");

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("Nome é um campo obrigatório.")
            .MaximumLength(256)
            .WithMessage("Nome possui um tamanho máximo de 256 caracteres.")
            .WithErrorCode("FirstName");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Sobrenome é um campo obrigatório.")
            .MaximumLength(256)
            .WithMessage("Sobrenome possui um tamanho máximo de 256 caracteres.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Senha é um campo obrigatório.")
            .Matches(Constants.RegexPassword)
            .WithMessage("A senha não atende aos requisitos mínimos.")
            .MaximumLength(256)
            .WithMessage("Senha possui um tamanho máximo de 256 caracteres.");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Confirmação de senha é um campo obrigatório.")
            .MaximumLength(256)
            .WithMessage("Confirmação de senha possui um tamanho máximo de 256 caracteres.")
            .Equal(x => x.Password).WithMessage("As senhas não são iguais");
    }
}
