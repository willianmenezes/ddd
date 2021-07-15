using FluentValidation;
using NerdStore.Core.Messages;
using System;

namespace NerdStore.Vendas.Application.Commands
{
    public class IniciarPedidoCommand : Command
    {
        public IniciarPedidoCommand(Guid pedidoId, Guid clienteId, decimal valorTotal, string numeroCartao, string nomeCartao, string expiracaoCartao, string cvvCartao)
        {
            PedidoId = pedidoId;
            ClienteId = clienteId;
            ValorTotal = valorTotal;
            NumeroCartao = numeroCartao;
            NomeCartao = nomeCartao;
            ExpiracaoCartao = expiracaoCartao;
            CvvCartao = cvvCartao;
        }

        public Guid PedidoId { get; set; }
        public Guid ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public string NumeroCartao { get; set; }
        public string NomeCartao { get; set; }
        public string ExpiracaoCartao { get; set; }
        public string CvvCartao { get; set; }
    }

    public class IniciarPedidoCommandValidation : AbstractValidator<IniciarPedidoCommand>
    {
        public IniciarPedidoCommandValidation()
        {
            RuleFor(x => x.ClienteId)
               .NotEqual(Guid.Empty)
               .WithMessage("Id do cliente inválido");

            RuleFor(x => x.PedidoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do pedido inválido");

            RuleFor(x => x.NomeCartao)
               .Empty()
               .WithMessage("Nome do cartao não foi informado");

            RuleFor(x => x.NumeroCartao)
               .CreditCard()
               .WithMessage("Numero do cartao inválido");

            RuleFor(x => x.ExpiracaoCartao)
               .Empty()
               .WithMessage("Expiracao do cartao não foi informado");

            RuleFor(x => x.CvvCartao)
               .Length(3,4)
               .WithMessage("O CVV não foi preenchido corretamente");
        }
    }
}
