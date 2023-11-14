using FluentValidation;
using Teste.Seguro.Domain.Entity;

namespace Teste.Seguro.Service.Validators;

public class SeguroValidator : AbstractValidator<SeguroEntity>
{
    public SeguroValidator()
    {
        RuleFor(w => w.SeguradoId)
            .NotEmpty().WithMessage("Por favor, digite o nome do segurado.")
            .NotNull().WithMessage("Por favor, digite o nome do segurado.");

        RuleFor(w => w.SeguradoraId)
            .NotEmpty().WithMessage("Por favor, digite o CPF do segurado.")
            .NotNull().WithMessage("Por favor, digite o CPF do segurado.");

        RuleFor(w => w.VeiculoId)
            .NotEmpty().WithMessage("Por favor, digite o CPF do segurado.")
            .NotNull().WithMessage("Por favor, digite o CPF do segurado.");
    }
}
