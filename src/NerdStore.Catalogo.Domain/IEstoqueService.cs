using System;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain
{
    public interface IEstoqueService : IDisposable
    {
        Task<bool> DebitarEstoque(Guid produtoId, int quantidade);
        Task<bool> ReportarEstoque(Guid produtoId, int quantidade);
    }
}