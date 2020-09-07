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
    public class EscolaCommandQuery : ICommandMapped<Escola, int, List<Escola>>
    {

    }

    public class EscolaCommandHandlerQuery : CommandHandlerBase<IUnitOfWork>, ICommandHandler<EscolaCommandQuery, List<Escola>>
    {
        private readonly IEscolaRepository _repo;

        public EscolaCommandHandlerQuery(INotificationContext notificationContext, IUnitOfWork uow, IMapper mapper, IEscolaRepository repo) : base(notificationContext, uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<Escola>> Handle(EscolaCommandQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObterTodos();
        }
    }
}
