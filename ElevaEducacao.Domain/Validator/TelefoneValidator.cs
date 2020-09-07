using ElevaEducacao.Domain.Core.Validators;
using FluentValidation;

namespace ElevaEducacao.Domain.Validator
{
    public class TelefoneValidator : ValidatorBase<Telefone>
    {
        public override void ToValidate()
        {
            RuleFor(x => x.DDD).LessThanOrEqualTo(0)
                    .WithMessage("Indique um DDD valido.");

            RuleFor(x => x.Numero).LessThanOrEqualTo(7)
                    .GreaterThanOrEqualTo(10)
                    .WithMessage("Indique um número válido.");
        }
    }
}
