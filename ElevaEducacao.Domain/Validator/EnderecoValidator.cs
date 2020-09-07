using ElevaEducacao.Domain.Core.Validators;
using FluentValidation;

namespace ElevaEducacao.Domain.Validator
{
    public class EnderecoValidator : ValidatorBase<Endereco>
    {
        public override void ToValidate()
        {
            RuleFor(x => x).Must(x => x.Cidade != null)
                    .WithMessage("Indique uma cidade");

            RuleFor(x => x).Must(x => x.Bairro != null)
                    .WithMessage("Indique um bairro");

            RuleFor(x => x.Descricao).NotEmpty().NotNull()
                   .WithMessage("Indique uma localização do endereço");

            RuleFor(x => x.Numero).NotNull().NotEmpty()
                 .WithMessage("Indique o número do endereço");

            RuleFor(x => x.IdEscola).NotNull()
                  .WithMessage("Indique uma escola");
        }
    }
}
