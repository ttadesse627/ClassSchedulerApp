using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Persistence;
public class ClassRepository(ClassSchedulerDbContext context) : CommonRepository<Class>(context), IClassRepository
{
    private readonly ClassSchedulerDbContext _context = context;

    public async Task<bool> CreateAsync(Class cls, CancellationToken cancellationToken)
    {
        if (cls != null)
        {
            _context.Classes.Add(cls);
            var affectedRows = await _context.SaveChangesAsync(cancellationToken);
            if (affectedRows > 0) return true;
        }

        return false;
    }
    public async Task<List<Class>> GetAllAsync()
    {
        return await _context.Classes.ToListAsync();
    }

    public async Task<Class?> GetAsync(Guid id)
    {
        var cls = await _context.Classes.FindAsync(id);
        return cls;
    }

    public async Task<bool> DeleteClassesAsync(CancellationToken cancellationToken)
    {
        _context.Classes.RemoveRange();
        int affectedRows = await _context.SaveChangesAsync(cancellationToken);
        if (affectedRows > 0)
        {
            return true;
        }
        return false;
    }

    public async Task<bool> CreateListAsync(List<Class> classes, CancellationToken cancellationToken)
    {
        if (classes.Count > 0)
        {
            _context.Classes.AddRange(classes);
            var success = await _context.SaveChangesAsync(cancellationToken);

            if (success > 0)
            {
                return true;
            }
        };

        return false;
    }

    public async Task<List<Class>> GetBySectionAsync(Guid sectionId)
    {
        return await _context.Classes
            .Include(cl => cl.Section)
            .Include(cl => cl.Course)
            .Include(cl => cl.Instructor).ThenInclude(instr => instr.Person)
            .Include(cl => cl.Room)
            .Include(cl => cl.TimeSlot)
            .Where(cls => cls.SectionId == sectionId).ToListAsync();
    }
}