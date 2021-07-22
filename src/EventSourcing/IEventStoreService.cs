using EventStore.ClientAPI;
using System.Threading.Tasks;

namespace EventSourcing
{
    public interface IEventStoreService
    {
        IEventStoreConnection GetConnection();
    }
}
