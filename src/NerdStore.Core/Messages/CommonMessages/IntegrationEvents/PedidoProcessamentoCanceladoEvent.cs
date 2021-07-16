﻿using NerdStore.Core.DomainObjects.Dtos;
using System;

namespace NerdStore.Core.Messages.CommonMessages.IntegrationEvents
{
    public class PedidoProcessamentoCanceladoEvent : IntegrationEvent
    {
        public PedidoProcessamentoCanceladoEvent(Guid pedidoId, Guid clienteId, ListaProdutosPedido produtosPedido)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
            ClienteId = clienteId;
            ProdutosPedido = produtosPedido;
        }

        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }
        public ListaProdutosPedido ProdutosPedido { get; private set; }
    }
}
