using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Bus;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Vendas.Application.Commands;
using NerdStore.Vendas.Application.Queries;
using NerdStore.WebApp.API.Services;
using System;
using System.Threading.Tasks;

namespace NerdStore.WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : BaseController
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IMediatorHandler _mediatrHandler;
        private readonly IPedidoQueries _pedidoQueries;

        public CarrinhoController(IProdutoAppService produtoAppService,
                                  IMediatorHandler mediatrHandler,
                                  INotificationHandler<DomainNotification> domainNotification,
                                  IPedidoQueries pedidoQueries) : base(domainNotification, mediatrHandler)
        {
            _produtoAppService = produtoAppService;
            _mediatrHandler = mediatrHandler;
            _pedidoQueries = pedidoQueries;
        }

        [HttpGet("meu-carrinho")]
        public async Task<IActionResult> CarrinhoDeComprar()
        {
            return Ok(await _pedidoQueries.ObterCarrinhoCliente(ClienteId));
        }

        [HttpGet("remover-item")]
        public async Task<IActionResult> RemoverItem(Guid id)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            if (produto == null) return BadRequest();

            var command = new RemoverItemPedidoCommand(ClienteId, id);
            await _mediatrHandler.EnviarCommando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest("Erro ao remover item do carrinho, tente novamente");
        }

        [HttpGet("atualizar-item")]
        public async Task<IActionResult> AtualizarItem(Guid id, int quantidade)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            if (produto == null) return BadRequest();

            var command = new AtualizarPedidoCommand(ClienteId, id, quantidade);
            await _mediatrHandler.EnviarCommando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest("Erro ao atualizar item do carrinho, tente novamente");
        }

        [HttpGet("aplicar-voucher")]
        public async Task<IActionResult> AplicarVoucher(string codigoVoucher)
        {
            var command = new AplicarVoucherPedidoCommand(ClienteId, codigoVoucher);
            await _mediatrHandler.EnviarCommando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            return BadRequest("Erro ao aplicar voucher, tente novamente");
        }

        [HttpPost("meu-carrinho/{id}/{quantidade}")]
        public async Task<IActionResult> AdicionarItem([FromRoute] Guid id, [FromRoute] int quantidade)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            if (produto == null) return BadRequest();

            if (produto.QuantidadeEstoque < quantidade)
            {
                return BadRequest("Produto com quantidade insuficiente");
            }

            var command = new AdicionarItemPedidoCommand(ClienteId, produto.Id, produto.Nome, quantidade, produto.Valor);

            await _mediatrHandler.EnviarCommando(command);

            if (OperacaoValida())
            {
                return Ok();
            }

            var notificacoes = ObterNotificacoes();

            return BadRequest(notificacoes);
        }
    }
}
