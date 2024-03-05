using ClassScheduler.Application.Interfaces.Persistence.Common;
using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface IDepartmentRepository : ICommonRepository<Department>
{
    public Task<Department> CreateDepartmentAsync(Department department);
    public Task<List<Department>> GetAllAsync();
    public Task<Department> GetAsync(Guid id);
    public Task<bool> DeleteAsync(Department department);
    public Task<bool> UpdateAsync(Department department);
}