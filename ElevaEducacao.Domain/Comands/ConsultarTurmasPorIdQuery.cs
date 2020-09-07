using AutoMapper;
using ElevaEducacao.Domain.Core.Commands;
using ElevaEducacao.Domain.Core.Handlers;
using ElevaEducacao.Domain.Core.Interfaces;
using ElevaEducacao.Domain.Interfaces.Repository;
using ElevaEducacao.Infra.CrossCutting.NotificationPattern;
using System.Threading;
using System.Threading.Tasks;

namespace ElevaEducacao.Domain.Comands
{
    public class ConsultarTurmasPorIdQuery : ICommandMapped<Turma, int, Turma>
    {
        public int Id { get; set; }
    }

    public class ConsultarTurmasPorIdQueryHandler : CommandHandlerBase<IUnitOfWork>, ICommandHandler<ConsultarTurmasPorIdQuery, Turma>
    {
        private readonly ITurmaRepository _repo;
        public ConsultarTurmasPorIdQueryHandler(INotificationContext notificationContext
            , IUnitOfWork uow
            , ITurmaRepository repo
            , IMapper mapper) : base(notificationContext, uow, mapper)
        {
            _repo = repo;
        }

        public async Task<Turma> Handle(ConsultarTurmasPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObterPorId(request.Id);
        }
    }
}
