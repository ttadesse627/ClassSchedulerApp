
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface IFacultyRepository
{
    Task<ServiceResponse<int>> Create(Faculty faculty, CancellationToken cancellationToken);
    Task<ServiceResponse<Faculty>> GetAsync(Guid id);
    Task<List<Faculty>> GetAllAsync();

}