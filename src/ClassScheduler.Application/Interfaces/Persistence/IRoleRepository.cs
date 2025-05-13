using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface IRoleRepository
{
    Task<ServiceResponse<int>> CreateRoleAsync(Role role, CancellationToken cancellationToken);
    Task<List<Role>> GetRolesAsync(ICollection<Guid> roleIds);
    Task<Role?> GetAsync(Guid id);
    Task<List<Role>> GetAllAsync();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}