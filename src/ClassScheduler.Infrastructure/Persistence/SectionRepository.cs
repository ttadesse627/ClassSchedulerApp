using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Persistence;
public class SectionRepository(ClassSchedulerDbContext context) : CommonRepository<Section>(context), ISectionRepository
{
    private readonly ClassSchedulerDbContext _context = context;

    public async Task<bool> CreateSectionAsync(Section section)
    {
        bool response = false;
        if (section != null)
        {
            _context.Sections.Add(section);
            var affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0) response = true;
        }

        return response;
    }
    public async Task<List<Section>> GetAllAsync()
    {
        return await _context.Sections.ToListAsync();
    }

    public async Task<Section> GetAsync(Guid id)
    {
        var section = await _context.Sections.FindAsync(id);
        return section;
    }

    public async Task<bool> DeleteAsync(Section section)
    {
        bool success = false;
        if (section is not null)
        {
            _context.Sections.Remove(section);
            int affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0)
            {
                success = true;
            }
        }
        return success;
    }
    public async Task<bool> UpdateAsync(Section section)
    {
        bool success = false;
        if (section is not null)
        {
            _context.Sections.Update(section);
            int affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0)
            {
                success = true;
            }
        }
        return success;
    }
}