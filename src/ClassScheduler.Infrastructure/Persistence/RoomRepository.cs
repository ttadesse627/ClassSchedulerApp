using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Persistence;
public class RoomRepository(ClassSchedulerDbContext context) : IRoomRepository
{
    private readonly ClassSchedulerDbContext _context = context;

    public async Task<bool> CreateAsync(Room room)
    {
        bool response = false;
        if (room != null)
        {
            _context.Rooms.Add(room);
            var affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0) response = true;
        }

        return response;
    }
    public async Task<bool> CreateMultiAsync(IList<Room> rooms)
    {
        bool response = false;
        if (rooms.Count > 0)
        {
            _context.Rooms.AddRange(rooms);
            var affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0) response = true;
        }

        return response;
    }

    public async Task<bool> DeleteAsync(Room room)
    {
        bool success = false;
        if (room is not null)
        {
            _context.Rooms.Remove(room);
            int affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0)
            {
                success = true;
            }
        }
        return success;
    }

    public async Task<List<Room>> GetAllAsync()
    {
        return await _context.Rooms.ToListAsync();
    }

    public async Task<Room?> GetAsync(Guid id)
    {
        var room = await _context.Rooms.FindAsync(id);
        return room;
    }

    public async Task<bool> UpdateAsync(Room room)
    {
        bool success = false;
        if (room is not null)
        {
            _context.Rooms.Update(room);
            int affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0)
            {
                success = true;
            }
        }
        return success;
    }
}