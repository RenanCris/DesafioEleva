using AutoMapper;
using ElevaEducacao.Infra.CrossCutting.NotificationPattern;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ElevaEducacao.Controllers
{
    public abstract class ApiControllerBase : Controller
    {
        protected INotificationContext NotificationContext => _domainNotificationContext ??= HttpContext.RequestServices.GetService<INotificationContext>();
        private INotificationContext _domainNotificationContext;

        protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
        private IMapper _mapper;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator _mediator;

        protected bool IsViewModelInvalid()
        {
            if (ModelState.IsValid) return false;

            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                SetValidationError(erroMsg);
            }

            return true;
        }
        protected void SetValidationError(string mensagem)
        {
            _domainNotificationContext.AddNotification(mensagem);
        }

        protected new IActionResult Response(object data = null)
        {
            if (!_domainNotificationContext.HasNotifications)
                return base.Ok(FormatSuccessResponse(data));

            return base.BadRequest(FormatFailResponse(_domainNotificationContext.Notifications.Select(x => x.Message).ToArray()));
        }

        protected IActionResult DirectOk(object data = null)
        {
            return base.Ok(data);
        }
        protected new IActionResult Ok(object data = null)
        {
            return base.Ok(FormatSuccessResponse(data));
        }
        protected IActionResult Ok<T>(object data = null)
        {
            return base.Ok(FormatSuccessResponse<T>(data));
        }
        protected new IActionResult BadRequest()
        {
            return base.BadRequest(FormatFailResponse(_domainNotificationContext.Notifications.Select(x => x.Message).ToArray()));
        }

        private static object FormatSuccessResponse(object data)
        {
            return new
            {
                success = true,
                data = data
            };
        }
        private object FormatSuccessResponse<T>(object data)
        {
            return new
            {
                success = true,
                data = _mapper.Map<T>(data)
            };
        }
        private static object FormatFailResponse(string[] errors)
        {
            return new
            {
                success = false,
                errors = errors
            };
        }
    }
}