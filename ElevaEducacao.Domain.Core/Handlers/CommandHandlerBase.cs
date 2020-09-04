using ElevaEducacao.Domain.Core.Entities;
using ElevaEducacao.Domain.Core.Interfaces;
using ElevaEducacao.Infra.CrossCutting.NotificationPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElevaEducacao.Domain.Core.Handlers
{
    public abstract class CommandHandlerBase<TUnitOfWork>
        where TUnitOfWork : IUnitOfWork
    {
        private readonly TUnitOfWork _uow;
        private readonly INotificationContext _notificationContext;
       
        protected CommandHandlerBase(
            INotificationContext notificationContext,
            TUnitOfWork uow)
        {
            _uow = uow;
            _notificationContext = notificationContext;
        }

        protected Unit Finish() => Unit.Value;
        protected TResponse Fail<TResponse>(TResponse response)
        {
            return response;
        }
        protected Unit Fail(string message)
        {
            _notificationContext.AddNotification(message);
            return Unit.Value;
        }
        protected TResponse Fail<TResponse>(string message, TResponse response)
        {
            _notificationContext.AddNotification(message);
            return response;
        }
        protected Unit Fail(string[] messages)
        {
            _notificationContext.AddNotifications(messages);
            return Unit.Value;
        }
        protected TResponse Fail<TResponse>(string[] messages, TResponse response)
        {
            _notificationContext.AddNotifications(messages);
            return response;
        }
       
        protected bool IsValid<T, TPrimaryKey>(T entity)
            where T : IEntity<TPrimaryKey>
        {
            if (entity.IsValid()) return true;
            _notificationContext.AddNotifications(entity.ValidationResult);
            return false;
        }
        protected bool IsValid<T>(T entity) where T : IEntity<int>
        {
            return IsValid<T, int>(entity);
        }

        protected void AddNotification(string message) => _notificationContext.AddNotification(message);

        protected async Task<bool> Commit()
        {
            if (_notificationContext.HasNotifications) return false;
            if (await _uow.CommitAsync())
                return true;

            _notificationContext.AddNotification("Error ao comitar");
            return false;
        }
    }
}
