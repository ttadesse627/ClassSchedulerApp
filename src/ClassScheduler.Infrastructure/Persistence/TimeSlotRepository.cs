using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Persistence;
public class TimeSlotRepository(ClassSchedulerDbContext context) : ITimeSlotRepository
{
    private readonly ClassSchedulerDbContext _context = context;

    public async Task<bool> CreateAsync(TimeSlot TimeSlot)
    {
        bool response = false;
        if (TimeSlot != null)
        {
            _context.TimeSlots.Add(TimeSlot);
            var affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0) response = true;
        }

        return response;
    }
    public async Task<bool> CreateMultiAsync(IList<TimeSlot> TimeSlots)
    {
        bool response = false;
        if (TimeSlots.Count > 0)
        {
            _context.TimeSlots.AddRange(TimeSlots);
            var affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0) response = true;
        }

        return response;
    }

    public async Task<bool> DeleteAsync(TimeSlot TimeSlot)
    {
        bool success = false;
        if (TimeSlot is not null)
        {
            _context.TimeSlots.Remove(TimeSlot);
            int affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0)
            {
                success = true;
            }
        }
        return success;
    }

    public async Task<List<TimeSlot>> GetAllAsync()
    {
        return await _context.TimeSlots.ToListAsync();
    }

    public async Task<TimeSlot?> GetAsync(Guid id)
    {
        var TimeSlot = await _context.TimeSlots.FindAsync(id);
        return TimeSlot;
    }

    public async Task<bool> UpdateAsync(TimeSlot TimeSlot)
    {
        bool success = false;
        if (TimeSlot is not null)
        {
            _context.TimeSlots.Update(TimeSlot);
            int affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0)
            {
                success = true;
            }
        }
        return success;
    }
}