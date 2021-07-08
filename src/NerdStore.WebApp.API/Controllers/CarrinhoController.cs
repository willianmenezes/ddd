using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Bus;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Vendas.Application.Commands;
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

        public CarrinhoController(IProdutoAppService produtoAppService,
                                  IMediatorHandler mediatrHandler,
                                  INotificationHandler<DomainNotification> domainNotification) : base(domainNotification, mediatrHandler)
        {
            _produtoAppService = produtoAppService;
            _mediatrHandler = mediatrHandler;
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
        z}
    }
}
