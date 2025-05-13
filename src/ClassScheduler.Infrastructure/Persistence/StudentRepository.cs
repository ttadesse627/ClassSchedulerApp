using System.Text.Json;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Persistence;
public class StudentRepository(ClassSchedulerDbContext dbContext) : IStudentRepository
{
    private readonly ClassSchedulerDbContext _context = dbContext;

    public async Task<bool> CreateStudentAsync(Student student)
    {
        var response = new ServiceResponse<int>();
        var success = false;
        await _context.Students!.AddAsync(student);
        Console.WriteLine($"Response before serialization: {JsonSerializer.Serialize(response)}");
        var affectedRows = await _context.SaveChangesAsync();

        if (affectedRows > 0)
        {
            success = true;
        }
        return success;
    }

    public async Task<ICollection<Student>> GetStudentsListAsync()
    {
        var response = await _context.Students!.ToListAsync();
        return response;
    }
    public async Task<Student> GetAsync(Guid id)
    {
        var student = await _context.Students!.FindAsync(id);
        return student!;
    }

    public async Task<bool> DeleteAsync(Student student)
    {
        bool success = false;
        if (student is not null)
        {
            _context.Students!.Remove(student);
            int affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0)
            {
                success = true;
            }
        }
        return success;
    }
}