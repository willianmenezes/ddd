using FluentValidation;
using NerdStore.Core.Messages;
using System;

namespace NerdStore.Vendas.Application.Commands
{
    public class AtualizarPedidoCommand : Command
    {
        public AtualizarPedidoCommand(Guid clienteId, Guid produtoId, int quantidade)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }

        public Guid ClienteId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public int Quantidade { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarPedidoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AtualizarPedidoCommandValidation : AbstractValidator<AtualizarPedidoCommand>
    {
        public AtualizarPedidoCommandValidation()
        {
            RuleFor(x => x.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(x => x.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do produto inválido");

            RuleFor(x => x.Quantidade)
                .GreaterThan(0)
                .WithMessage("A quantidade mínima permitida é 1");

            RuleFor(x => x.Quantidade)
                .LessThan(15)
                .WithMessage("A quantidade máxima permitida é 15");
        }
    }
}
