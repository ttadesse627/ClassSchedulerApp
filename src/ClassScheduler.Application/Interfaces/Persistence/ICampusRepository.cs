
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface ICampusRepository
{
    Task<ServiceResponse<int>> Create(Campus campus, CancellationToken cancellationToken);
    Task<ServiceResponse<Campus>> GetAsync(Guid id);
    Task<List<Campus>> GetAllAsync();

}