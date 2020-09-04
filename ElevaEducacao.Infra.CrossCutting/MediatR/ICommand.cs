using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElevaEducacao.Infra.CrossCutting.MediatR
{
    public interface ICommand : IRequest
    {

    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {

    }
}
