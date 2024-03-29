﻿using System;

namespace NerdStore.Core.Messages.CommonMessages.IntegrationEvents
{
    public class PedidoEstoqueRejeitadoEvent: IntegrationEvent
    {
        public PedidoEstoqueRejeitadoEvent(Guid pedidoId, Guid clienteId)
        {
            PedidoId = pedidoId;
            ClienteId = clienteId;
        }

        public Guid PedidoId { get; set; }
        public Guid ClienteId { get; set; }
    }
}
