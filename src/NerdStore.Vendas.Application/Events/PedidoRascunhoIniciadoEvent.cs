﻿using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Application.Events
{
    public class PedidoRascunhoIniciadoEvent : Event
    {
        public PedidoRascunhoIniciadoEvent(Guid clienteId, Guid pedidoId)
        {
            AggregateId = PedidoId;
            ClienteId = clienteId;
            PedidoId = pedidoId;
        }

        public Guid ClienteId { get; private set; }
        public Guid PedidoId { get; private set; }
    }
}
