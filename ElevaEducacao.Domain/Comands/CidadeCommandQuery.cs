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
    public class CidadeCommandQuery : ICommandMapped<Cidade, int, List<Cidade>>
    {

    }

    public class CidadePorUFCommandQuery : ICommandMapped<Cidade, int, List<Cidade>>
    {
        public int IdUF { get; set; }
    }
    public class CidadeCommandHandlerQuery : CommandHandlerBase<IUnitOfWork>, ICommandHandler<CidadeCommandQuery, List<Cidade>>
    {
        private readonly ICidadeRepository _repo;
        public CidadeCommandHandlerQuery(INotificationContext notificationContext
            , IUnitOfWork uow
            , ICidadeRepository repo
            , IMapper mapper) : base(notificationContext, uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<Cidade>> Handle(CidadeCommandQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObterTodos();
        }
    }

    public class CidadeCommandPorUFHandlerQuery : CommandHandlerBase<IUnitOfWork>, ICommandHandler<CidadePorUFCommandQuery, List<Cidade>>
    {
        private readonly ICidadeRepository _repo;
        public CidadeCommandPorUFHandlerQuery(INotificationContext notificationContext
            , IUnitOfWork uow
            , ICidadeRepository repo
            , IMapper mapper) : base(notificationContext, uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<Cidade>> Handle(CidadePorUFCommandQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObterPorUF(request.IdUF);
        }
    }

}
