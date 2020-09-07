using AutoMapper;
using ElevaEducacao.Domain.Core.Commands;
using ElevaEducacao.Domain.Core.Handlers;
using ElevaEducacao.Domain.Core.Interfaces;
using ElevaEducacao.Domain.Interfaces.Repository;
using ElevaEducacao.Infra.CrossCutting.NotificationPattern;
using MediatR;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElevaEducacao.Domain.Comands
{
    public class CadastrarTurmaCommand : ICommandMapped<Turma>
    {
        public string CodigoPesquisa { get; set; }
        public int IdEscola { get; set; }
        public int HorasAula { get; set; }
        public int TotalVagas { get; set; }
        public int TotalVagasOcupadas { get; set; }
    }

    public class CadastrarTurmaCommandHandler: CommandHandlerBase<IUnitOfWork>, ICommandHandler<CadastrarTurmaCommand>
    {
        private readonly ITurmaRepository _repo;
        private readonly IEscolaRepository _repoEscola;
        public CadastrarTurmaCommandHandler(INotificationContext notificationContext
            , IUnitOfWork uow
            , ITurmaRepository repo
            , IMapper mapper
            , IEscolaRepository repoEscola) : base(notificationContext, uow, mapper)
        {
            _repo = repo;
            _repoEscola = repoEscola;
        }

        public async Task<Unit> Handle(CadastrarTurmaCommand request, CancellationToken cancellationToken)
        {
            var _turma = Mapper.Map<Turma>(request);

            if (await _repo.ExisteTurmaParaCodigoPesquisa(_turma)) return Fail("Já existe alguma turma com esse código de pesquisa!");
            if (!await _repoEscola.Existe(_turma.IdEscola)) return Fail("A Escola não existe");

            if (!IsValid<Turma>(_turma)) return Finish();

            await _repo.Criar(_turma);

            await Commit();

            return Finish();
        }
    }
}
