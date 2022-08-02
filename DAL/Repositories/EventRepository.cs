using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(EventContext eventContext)
        : base(eventContext)
        { }

        public async Task<Event?> GetByTheme(string eventTheme, CancellationToken cancellationToken)
        {
            return await _eventContext.Events.SingleOrDefaultAsync(x => x.Theme == eventTheme, cancellationToken);
        }
    }
}
