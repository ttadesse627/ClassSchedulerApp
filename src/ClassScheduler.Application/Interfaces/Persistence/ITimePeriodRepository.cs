using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface ITimePeriodRepository
{
    public Task<bool> CreateAsync(TimePeriod timePeriod);
    public Task<bool> CreateMultiAsync(IList<TimePeriod> timePeriods);
    public Task<List<TimePeriod>> GetAllAsync();
    public Task<TimePeriod?> GetAsync(Guid id);
    public Task<bool> DeleteAsync(TimePeriod timePeriod);
    public Task<bool> UpdateAsync(TimePeriod timePeriod);
}