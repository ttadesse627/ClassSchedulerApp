using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Persistence;
public class CourseRepository(ClassSchedulerDbContext context) : ICourseRepository
{
    private readonly ClassSchedulerDbContext _context = context;
    public async Task<bool> CreateAsync(ICollection<Course> course)
    {
        if (course != null)
        {
            try
            {
                _context.Courses.AddRange(course);
                int rows = await _context.SaveChangesAsync();
                if (rows > 0)
                {
                    return true;
                }
            }
            catch (Exception exc)
            {
                throw new DbUpdateException("Error occurred while saving an entity changes: ", exc);
            }
        }
        return false;
    }

    public async Task<bool> DeleteAsync(Course course)
    {
        _context.Courses.Remove(course);
        try
        {
            int affected = await _context.SaveChangesAsync();
            if (affected > 0)
            {
                return true;
            }
        }
        catch (Exception exc)
        {

            throw new DbUpdateException("Error occurred while saving an entity changes: ", exc);
        }
        return false;
    }

    public async Task<List<Course>> GetAllAsync()
    {
        return await _context.Courses.Include(course => course.DeptBatch).ToListAsync();
    }

    public async Task<List<Course>> GetByIdsAsync(List<Guid> ids)
    {
        return await _context.Courses.Where(course => ids.Contains(course.Id)).ToListAsync();
    }

    public async Task<Course?> GetAsync(Guid Id)
    {
        return await _context.Courses.FindAsync(Id);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}