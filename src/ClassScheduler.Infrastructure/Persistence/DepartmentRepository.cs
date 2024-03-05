using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Persistence;
public class DepartmentRepository(ClassSchedulerDbContext context) : CommonRepository<Department>(context), IDepartmentRepository
{
    private readonly ClassSchedulerDbContext _context = context;

    public async Task<Department> CreateDepartmentAsync(Department department)
    {
        var response = new Department();
        if (department != null)
        {
            _context.Departments!.Add(department);
            var affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0) response = await _context.Departments.FindAsync(department.Id);
        }

        return response!;
    }
    public async Task<List<Department>> GetAllAsync()
    {
        return await _context.Departments!.ToListAsync();
    }

    public async Task<Department> GetAsync(Guid id)
    {
        var department = await _context.Departments!.FindAsync(id);
        return department!;
    }

    public async Task<bool> DeleteAsync(Department department)
    {
        bool success = false;
        if (department is not null)
        {
            _context.Departments!.Remove(department);
            int affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0)
            {
                success = true;
            }
        }
        return success;
    }
    public async Task<bool> UpdateAsync(Department department)
    {
        bool success = false;
        if (department is not null)
        {
            _context.Departments!.Update(department);
            int affectedRows = await _context.SaveChangesAsync();
            if (affectedRows > 0)
            {
                success = true;
            }
        }
        return success;
    }
}