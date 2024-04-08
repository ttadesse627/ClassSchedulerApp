using System.Text.Json;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Persistence;
public class InstructorRepository(ClassSchedulerDbContext dbContext) : IInstructorRepository
{
    private readonly ClassSchedulerDbContext _context = dbContext;

    public async Task<bool> CreateAsync(Instructor instructor)
    {
        var response = new ServiceResponse<int>();
        var success = false;
        await _context.Instructors.AddAsync(instructor);
        Console.WriteLine($"Response before serialization: {JsonSerializer.Serialize(response)}");
        var affectedRows = await _context.SaveChangesAsync();

        if (affectedRows > 0)
        {
            success = true;
        }
        return success;
    }

    public async Task<IList<Instructor>> GetListAsync()
    {
        var response = await _context.Instructors.ToListAsync();
        return response;
    }
    public async Task<Instructor?> GetAsync(Guid id)
    {
        var instructor = await _context.Instructors.FindAsync(id);
        return instructor;
    }

    public async Task<bool> DeleteAsync(Instructor instructor)
    {
        bool success = false;
        if (instructor is not null)
        {
            _context.Instructors.Remove(instructor);
            int affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0)
            {
                success = true;
            }
        }
        return success;
    }
}