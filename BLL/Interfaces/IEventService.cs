using BLL.Models;

namespace BLL.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventModel>> Get(CancellationToken cancellationToken);
        Task<EventModel> Get(int id, CancellationToken cancellationToken);
        Task<EventModel> Create(EventModel EventModel, CancellationToken cancellationToken);
        Task<EventModel> Update(EventModel EventModel, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
