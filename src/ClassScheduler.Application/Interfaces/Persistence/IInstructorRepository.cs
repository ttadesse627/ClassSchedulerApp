using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface IInstructorRepository
{
    public Task<bool> CreateAsync(Instructor instructor);
    public Task<IList<Instructor>> GetListAsync();
    public Task<Instructor?> GetAsync(Guid id);
    public Task<bool> DeleteAsync(Instructor instructor);
}