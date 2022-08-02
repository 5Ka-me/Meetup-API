using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(EventContext eventContext)
        : base(eventContext)
        { }
    }
}
