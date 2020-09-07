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
    public class BairroCommandQuery : ICommandMapped<Bairro, int, List<Bairro>>
    {

    }

    public class BairroCommandHandlerQuery : CommandHandlerBase<IUnitOfWork>, ICommandHandler<BairroCommandQuery, List<Bairro>>
    {
        private readonly IBairroRepository _repo;
        public BairroCommandHandlerQuery(INotificationContext notificationContext
            , IUnitOfWork uow
            , IBairroRepository repo) : base(notificationContext, uow)
        {
            _repo = repo;
        }

        public async Task<List<Bairro>> Handle(BairroCommandQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObterTodos();
        }
    }
}
