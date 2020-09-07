using AutoMapper;
using ElevaEducacao.Domain.Core.Commands;
using ElevaEducacao.Domain.Core.Handlers;
using ElevaEducacao.Domain.Core.Interfaces;
using ElevaEducacao.Domain.Interfaces.Repository;
using ElevaEducacao.Infra.CrossCutting.NotificationPattern;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ElevaEducacao.Domain.Comands
{
    public class ConsultarTurmasPorEscolaQuery : ICommandMapped<Turma, int, List<Turma>>
    {
        public int IdEscola { get; set; }
    }

    public class ConsultarTurmasPorEscolaQueryHandler : CommandHandlerBase<IUnitOfWork>, ICommandHandler<ConsultarTurmasPorEscolaQuery, List<Turma>>
    {
        private readonly ITurmaRepository _repo;
        public ConsultarTurmasPorEscolaQueryHandler(INotificationContext notificationContext
            , IUnitOfWork uow
            , ITurmaRepository repo
            , IMapper mapper) : base(notificationContext, uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<Turma>> Handle(ConsultarTurmasPorEscolaQuery request, CancellationToken cancellationToken)
        {
            return await _repo.Buscar(x => x.IdEscola == request.IdEscola);
        }
    }
}
