using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NerdStore.WebApp.API.DTOs;

namespace NerdStore.WebApp.API.Services
{
    public interface IProdutoAppService : IDisposable
    {
        Task<IEnumerable<ProdutoDto>> ObterPorCategoria(int codigo);
        Task<ProdutoDto> ObterPorId(Guid produtoId);
        Task<IEnumerable<ProdutoDto>> ObterPorTodos();
        Task<IEnumerable<CategoriaDto>> ObterCategorias();
        
        Task AdicionarProduto(ProdutoDto produtoDto);
        Task AtualizarProduto(ProdutoDto produtoDto);
        
        Task<ProdutoDto> DebitarEstoque(Guid id, int quantidade);
        Task<ProdutoDto> ReporEstoque(Guid id, int quantidade);
    }
}