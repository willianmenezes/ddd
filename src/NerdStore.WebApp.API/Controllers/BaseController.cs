using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Bus;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using System;
using System.Collections.Generic;

namespace NerdStore.WebApp.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly DomainNotificationHandler _domainNotificationHandler;
        private readonly IMediatorHandler _mediatorHandler;

        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

        protected BaseController(INotificationHandler<DomainNotification> domainNotificationHandler, IMediatorHandler mediatorHandler)
        {
            _domainNotificationHandler = (DomainNotificationHandler)domainNotificationHandler;
            _mediatorHandler = mediatorHandler;
        }

        protected bool OperacaoValida()
        {
            return !_domainNotificationHandler.TemNotificacao();
        }

        protected List<DomainNotification> ObterNotificacoes()
        {
            return _domainNotificationHandler.ObterNotificacoes();
        }

        protected void NotificarErro(string codigo, string message)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, message));
        }

    }
}
