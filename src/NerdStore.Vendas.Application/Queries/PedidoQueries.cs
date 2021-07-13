using NerdStore.Vendas.Application.Queries.ViewModels;
using NerdStore.Vendas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Application.Queries
{
    public class PedidoQueries : IPedidoQueries
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoQueries(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<CarrinhoViewModel> ObterCarrinhoCliente(Guid clienteId)
        {
            var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(clienteId);

            if (pedido == null) return null;

            var carrinho = new CarrinhoViewModel
            {
                ClienteId = pedido.ClienteId,
                ValorTotal = pedido.ValorTotal,
                PedidoId = pedido.Id,
                SubTotal = pedido.Desconto + pedido.ValorTotal,
                ValorDesconto = pedido.Desconto
            };

            if (pedido.Voucher != null)
            {
                carrinho.VoucherCodigo = pedido.Voucher.Codigo;
            }

            foreach (var item in pedido.PedidoItens)
            {
                carrinho.Items.Add(new CarrinhoItemViewModel
                {
                    ProdutoId = item.ProdutoId,
                    ProdutoNome = item.ProdutoNome,
                    Quantidade = item.Quantidade,
                    ValorTotal = item.ValorUnitario * item.Quantidade,
                    ValorUnitario = item.ValorUnitario
                });
            }

            return carrinho;
        }

        public async Task<IEnumerable<PedidoViewModel>> ObterPedidosCliente(Guid clienteId)
        {
            var pedidos = await _pedidoRepository.ObterListaPorClienteId(clienteId);

            pedidos = pedidos.Where(x => x.PedidoStatus == PedidoStatus.Pago || x.PedidoStatus == PedidoStatus.Cancelado).OrderByDescending(x => x.Codigo);

            if (pedidos == null) return null;

            var pedidoViewModel = new List<PedidoViewModel>();

            foreach (var pedido in pedidos)
            {
                pedidoViewModel.Add(new PedidoViewModel
                {
                    Codigo = pedido.Codigo,
                    DataCadastro = pedido.DataCadastro,
                    PedidoStatus = (int)pedido.PedidoStatus,
                    ValorTotal = pedido.ValorTotal
                });
            }

            return pedidoViewModel;
        }
    }
}
