using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface ITimeSlotRepository
{
    public Task<bool> CreateAsync(TimeSlot TimeSlot);
    public Task<bool> CreateMultiAsync(IList<TimeSlot> TimeSlots);
    public Task<List<TimeSlot>> GetAllAsync();
    public Task<TimeSlot?> GetAsync(Guid id);
    public Task<bool> DeleteAsync(TimeSlot TimeSlot);
    public Task<bool> UpdateAsync(TimeSlot TimeSlot);
}