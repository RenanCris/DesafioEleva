using ElevaEducacao.Domain.Core.Validators;
using FluentValidation;

namespace ElevaEducacao.Domain.Validator
{
    public class TurmaValidator : ValidatorBase<Turma>
    {
        public override void ToValidate()
        {

            RuleFor(x => x.CodigoPesquisa).NotEmpty()
                .WithMessage("Código de pesquisa n~´ao informado.");

            RuleFor(x => x.CodigoPesquisa).MaximumLength(10)
                    .WithMessage("Código de pesquisa inválido.");

            RuleFor(x => x.HorasAula).Must(x => x >= TurmaConst.MinimoHoras)
                    .WithMessage("Mínimo de horas não foi alcançado.");

            RuleFor(x => x.TotalVagas).Must(x => x >= TurmaConst.MinimoVagas)
                  .WithMessage("Mínimo de vagas não foi alcançado.");
        }

        //private static bool VerificarMenorQue()
    }
}
