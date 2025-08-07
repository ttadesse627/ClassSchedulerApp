using ClassScheduler.Application.Interfaces.Persistence.Common;
using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface IDeptBatchRepository : ICommonRepository<DeptBatch>
{
    public Task<bool> CreateDeptBatchAsync(DeptBatch departmentBatches);
    public Task<List<DeptBatch>> GetAllAsync();
    public Task<DeptBatch> GetAsync(Guid id);
    public Task<bool> DeleteAsync(DeptBatch departmentBatch);
    public Task<bool> UpdateAsync(DeptBatch departmentBatch);
}