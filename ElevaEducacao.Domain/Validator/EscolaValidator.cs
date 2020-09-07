using ElevaEducacao.Domain.Core.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevaEducacao.Domain.Validator
{
    public class EscolaValidator : ValidatorBase<Escola>
    {
        public override void ToValidate()
        {
            RuleFor(x => x.Nome).NotEmpty()
                    .WithMessage("Nome não informado")
                    .MaximumLength(255)
                    .WithMessage("Tamanho máximo atingido");

            RuleFor(x=> x).Must(ValidarIndicacaoTelefone)
                    .WithMessage("Indique algum telefone.");

            RuleFor(x => x).Must(ValidarIndicacaoModadlidade)
                    .WithMessage("Indique alguma modalidade de ensino.");
        }

        private bool ValidarIndicacaoTelefone(Escola e) {
           return e.Telefones.Count != 0;
        }

        private bool ValidarIndicacaoModadlidade(Escola e)
        {
            return e.Modalidades.Count != 0;
        }
    }
}
