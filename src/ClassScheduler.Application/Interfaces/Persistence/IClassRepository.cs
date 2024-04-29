using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface IClassRepository
{
    public Task<bool> CreateAsync(Class cls, CancellationToken cancellationToken);
    public Task<bool> CreateListAsync(List<Class> classes, CancellationToken cancellationToken);
    public Task<List<Class>> GetAllAsync();
    public Task<List<Class>> GetByDepartmentAsync(Guid departmentId);
    public Task<Class?> GetAsync(Guid id);
    public Task<bool> DeleteClassesAsync(CancellationToken cancellationToken);
}