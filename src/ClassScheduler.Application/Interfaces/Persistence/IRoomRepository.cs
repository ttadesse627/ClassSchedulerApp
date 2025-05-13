using ClassScheduler.Application.Interfaces.Persistence.Common;
using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface IRoomRepository
{
    public Task<bool> CreateAsync(Room room);
    public Task<bool> CreateMultiAsync(IList<Room> rooms);
    public Task<List<Room>> GetAllAsync();
    public Task<Room?> GetAsync(Guid id);
    public Task<bool> DeleteAsync(Room room);
    public Task<bool> UpdateAsync(Room room);
}