
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface IExamRepository
{
    Task<ServiceResponse<int>> Create(Exam Exam, CancellationToken cancellationToken);
    Task<ServiceResponse<Exam>> GetAsync(Guid id);
    Task<List<Exam>> GetAllAsync();

}