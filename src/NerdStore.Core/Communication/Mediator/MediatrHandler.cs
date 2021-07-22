using System.Threading.Tasks;
using MediatR;
using NerdStore.Core.Data.EventSourcing;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.Core.Bus
{
    public class MediatrHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventSourcingRepository _eventSourcingRepository;

        public MediatrHandler(IMediator mediator, IEventSourcingRepository eventSourcingRepository)
        {
            _mediator = mediator;
            _eventSourcingRepository = eventSourcingRepository;
        }

        public async Task<bool> EnviarCommando<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);

            if (!evento.GetType().BaseType.Name.Equals("DomainEvent"))
            {
                await _eventSourcingRepository.SalvarEvento(evento);
            }
        }

        public async Task PublicarNotificacao<T>(T command) where T : DomainNotification
        {
            await _mediator.Publish(command);
        }
    }
}