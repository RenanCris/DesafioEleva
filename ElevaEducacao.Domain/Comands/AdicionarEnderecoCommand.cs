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
    public class AdicionarEnderecoCommand : ICommandMapped<Endereco>
    {
        public int IdCidade { get; set; }
        public int IdBairro { get; set; }
        public int IdEscola { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Descricao { get; set; }
    }

    public class AdicionarEnderecoCommandHandler : CommandHandlerBase<IUnitOfWork>, ICommandHandler<AdicionarEnderecoCommand>
    {
        private readonly IEnderecoRepository _repo;
        public AdicionarEnderecoCommandHandler(INotificationContext notificationContext
            , IUnitOfWork uow
            , IEnderecoRepository repo
            , IMapper mapper) : base(notificationContext, uow, mapper)
        {
            _repo = repo;
        }

        public Task<Unit> Handle(AdicionarEnderecoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
