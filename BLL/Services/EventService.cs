using BLL.Interfaces;
using BLL.Models;

namespace BLL.Services
{
    public class EventService : IEventService
    {
        public Task<EventModel> Create(EventModel EventModel, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EventModel>> Get(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<EventModel> Get(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<EventModel> Update(EventModel EventModel, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
