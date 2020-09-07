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
    public class ConsultarTurmasQuery : ICommandMapped<Turma,int, List<Turma>>
    {
    }

    public class ConsultarTodasTurmasQueryHandler : CommandHandlerBase<IUnitOfWork>, ICommandHandler<ConsultarTurmasQuery, List<Turma>>
    {
        private readonly ITurmaRepository _repo;
        public ConsultarTodasTurmasQueryHandler(INotificationContext notificationContext
            , IUnitOfWork uow
            , ITurmaRepository repo
            , IMapper mapper) : base(notificationContext, uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<Turma>> Handle(ConsultarTurmasQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObterTodos();
        }
    }
}
