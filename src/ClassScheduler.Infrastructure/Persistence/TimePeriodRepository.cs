using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Persistence;
public class TimePeriodRepository(ClassSchedulerDbContext context) : ITimePeriodRepository
{
    private readonly ClassSchedulerDbContext _context = context;

    public async Task<bool> CreateAsync(TimePeriod timePeriod)
    {
        bool response = false;
        if (timePeriod != null)
        {
            _context.TimePeriods.Add(timePeriod);
            var affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0) response = true;
        }

        return response;
    }
    public async Task<bool> CreateMultiAsync(IList<TimePeriod> timePeriods)
    {
        bool response = false;
        if (timePeriods.Count > 0)
        {
            _context.TimePeriods.AddRange(timePeriods);
            var affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0) response = true;
        }

        return response;
    }

    public async Task<bool> DeleteAsync(TimePeriod timePeriod)
    {
        bool success = false;
        if (timePeriod is not null)
        {
            _context.TimePeriods.Remove(timePeriod);
            int affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0)
            {
                success = true;
            }
        }
        return success;
    }

    public async Task<List<TimePeriod>> GetAllAsync()
    {
        return await _context.TimePeriods.ToListAsync();
    }

    public async Task<TimePeriod?> GetAsync(Guid id)
    {
        var timePeriod = await _context.TimePeriods.FindAsync(id);
        return timePeriod;
    }

    public async Task<bool> UpdateAsync(TimePeriod timePeriod)
    {
        bool success = false;
        if (timePeriod is not null)
        {
            _context.TimePeriods.Update(timePeriod);
            int affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0)
            {
                success = true;
            }
        }
        return success;
    }
}