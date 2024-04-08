using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface IRoleRepository
{
    Task<ServiceResponse<int>> CreateRoleAsync(Role role, CancellationToken cancellationToken);
    Task<List<Role>> GetRolesAsync(ICollection<Guid> roleIds);
    Task<List<Role>> GetAllAsync();
}