using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface IRoleRepository
{
    public Task<ServiceResponse<int>> CreateRoleAsync(Role role);
}