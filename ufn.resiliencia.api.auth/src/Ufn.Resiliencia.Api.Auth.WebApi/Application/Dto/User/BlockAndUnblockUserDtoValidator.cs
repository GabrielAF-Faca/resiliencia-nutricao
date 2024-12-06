using FluentValidation;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.User;

public class BlockAndUnblockUserDtoValidator : AbstractValidator<BlockAndUnblockUserDto>
{
    public BlockAndUnblockUserDtoValidator()
    {
        RuleFor(x => x.Username)
           .NotEmpty()
           .WithMessage("Usuário é um campo obrigatório.")
           .MaximumLength(256)
           .WithMessage("Usuário possui um tamanho máximo de 256 caracteres.")
           .EmailAddress()
           .WithMessage("E-mail informado é inválido.");

        RuleFor(x => x.IsBlocked)
            .NotNull()
            .WithMessage("IsBlocked não informado.");
    }
}
