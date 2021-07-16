using NerdStore.Core.DomainObjects.Dtos;
using System.Threading.Tasks;

namespace NerdStore.Pagamentos.Business
{
    public interface IPagamentoService
    {
        Task RealizarPagamentoPedido(PagamentoPedido pagamentoPedido);
    }
}