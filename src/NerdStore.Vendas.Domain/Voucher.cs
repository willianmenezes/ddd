using FluentValidation;
using FluentValidation.Results;
using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace NerdStore.Vendas.Domain
{
    public class Voucher : Entity
    {
        public string Codigo { get; private set; }
        public decimal? Percentual { get; private set; }
        public decimal? ValorDesconto { get; private set; }
        public int Quantidade { get; private set; }
        public TipoDescontoVoucher TipoDescontoVoucher { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataUtilizacao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public bool Ativo { get; private set; }
        public bool Utilizado { get; private set; }

        // EF RELATION
        public ICollection<Pedido> Pedidos { get; set; }

        public ValidationResult ValidarSeAplicavel()
        {
            return new VoucherAplicavelValidation().Validate(this);
        }
    }

    public class VoucherAplicavelValidation : AbstractValidator<Voucher>
    {
        public VoucherAplicavelValidation()
        {
            RuleFor(x => x.DataValidade)
                .Must(DataVencimentoSuperiorAtual)
                .WithMessage("Voucher expirado");

            RuleFor(x => x.Ativo)
                .Equal(true)
                .WithMessage("O voucher não esta mais ativo");

            RuleFor(x => x.Utilizado)
                .Equal(false)
                .WithMessage("Este voucher já foi utilizado");

            RuleFor(x => x.Quantidade)
                .GreaterThan(0)
                .WithMessage("Este voucher não esta mais disponível");

        }

        protected static bool DataVencimentoSuperiorAtual(DateTime dataValidate)
        {
            return dataValidate >= DateTime.Now;
        }
    }


}
