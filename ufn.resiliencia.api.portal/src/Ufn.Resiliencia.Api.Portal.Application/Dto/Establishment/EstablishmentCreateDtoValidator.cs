using FluentValidation;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Establishment;
public class EstablishmentCreateDtoValidator : AbstractValidator<EstablishmentCreateDto>
{
    public EstablishmentCreateDtoValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Nome do estabelecimento"))
            .MaximumLength(200)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Nome do estabelecimento", 200));

        RuleFor(r => r.ZipCode)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "CEP"))
            .Length(8)
            .WithMessage(string.Format(ApplicationValidationMessages.Length, "CEP", 8));

        RuleFor(r => r.Neighborhood)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Bairro"))
            .MaximumLength(200)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Bairro", 200));

        RuleFor(r => r.Street)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Logradouro"))
            .MaximumLength(200)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Logradouro", 200));

        RuleFor(r => r.City)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Município"))
            .MaximumLength(200)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Município", 200));

        RuleFor(r => r.State)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "UF"))
            .Length(2)
            .WithMessage(string.Format(ApplicationValidationMessages.Length, "UF", 2));

        RuleFor(r => r.Number)
            .NotEmpty()
            .WithMessage(string.Format(ApplicationValidationMessages.Required, "Número"))
            .MaximumLength(200)
            .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Número", 10));

        RuleFor(r => r.Complement)
           .MaximumLength(200)
           .WithMessage(string.Format(ApplicationValidationMessages.MaxLength, "Complemento", 200));

    }
}
