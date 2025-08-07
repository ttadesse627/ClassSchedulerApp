using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Persistence;
public class DeptBatchRepository(ClassSchedulerDbContext context) : CommonRepository<DeptBatch>(context), IDeptBatchRepository
{
    private readonly ClassSchedulerDbContext _context = context;

    public async Task<bool> CreateDeptBatchAsync(DeptBatch batch)
    {
        bool response = false;
        if (batch != null)
        {
            _context.Batches.Add(batch);
            var affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0) response = true;
        }

        return response;
    }
    public async Task<List<DeptBatch>> GetAllAsync()
    {
        return await _context.Batches.ToListAsync();
    }
    public async Task<List<DeptBatch>> GetForCourseAsync()
    {
        return await _context.Batches.ToListAsync();
    }

    public async Task<DeptBatch> GetAsync(Guid id)
    {
        var batch = await _context.Batches.FindAsync(id);
        return batch!;
    }

    public async Task<bool> DeleteAsync(DeptBatch batch)
    {
        bool success = false;
        if (batch is not null)
        {
            _context.Batches.Remove(batch);
            int affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0)
            {
                success = true;
            }
        }
        return success;
    }
    public async Task<bool> UpdateAsync(DeptBatch batch)
    {
        bool success = false;
        if (batch is not null)
        {
            _context.Batches.Update(batch);
            int affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0)
            {
                success = true;
            }
        }
        return success;
    }
}