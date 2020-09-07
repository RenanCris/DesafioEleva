using ElevaEducacao.Domain.Core.Validators;
using FluentValidation;

namespace ElevaEducacao.Domain.Validator
{
    public class TelefoneValidator : ValidatorBase<Telefone>
    {
        public override void ToValidate()
        {
            RuleFor(x => x.DDD).NotEmpty()
                    .WithMessage("Indique um DDD valido.");

            RuleFor(x => x.Numero).NotEmpty()
                    .WithMessage("Indique um número válido.");
        }
    }
}
