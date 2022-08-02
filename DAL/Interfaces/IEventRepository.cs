using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        Task<Event?> GetByTheme(string eventTheme, CancellationToken cancellationToken);
    }
}
