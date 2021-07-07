using Microsoft.AspNetCore.Mvc;
using NerdStore.WebApp.API.DTOs;
using NerdStore.WebApp.API.Services;
using System;
using System.Threading.Tasks;

namespace NerdStore.WebApp.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminProdutosController : BaseController
    {
        private readonly IProdutoAppService _produtoAppService;

        public AdminProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet("admin-produtos")]
        public async Task<IActionResult> BuscarProdutos()
        {
            return Ok(await _produtoAppService.ObterPorTodos());
        }

        [HttpPost("novo-produto")]
        public async Task<IActionResult> AdicionarProduto(ProdutoDto produtoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(produtoDto);
            }

            await _produtoAppService.AdicionarProduto(produtoDto);

            return Ok("Produto adicionado com sucesso!");
        }

        [HttpPost("produtos-atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id, int quantidade)
        {
            if (quantidade > 0)
            {
                await _produtoAppService.ReporEstoque(id, quantidade);
            }
            else
            {
                await _produtoAppService.DebitarEstoque(id, quantidade);
            }

            return Ok("Estoque atualizado com sucesso!");

        }
    }
}
