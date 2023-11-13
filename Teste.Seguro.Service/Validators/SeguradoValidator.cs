using FluentValidation;
using Teste.Seguro.Domain.Entity;

namespace Teste.Seguro.Service.Validators;

public class SeguradoValidator : AbstractValidator<SeguradoEntity>
{
    public SeguradoValidator()
    {
        RuleFor(w => w.Nome)
            .NotEmpty().WithMessage("Por favor, digite o nome do segurado.")
            .NotNull().WithMessage("Por favor, digite o nome do segurado.");

        RuleFor(w => w.CPF)
            .NotEmpty().WithMessage("Por favor, digite o CPF do segurado.")
            .NotNull().WithMessage("Por favor, digite o CPF do segurado.");
    }
}
