using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface ICourseRepository
{
    Task<bool> CreateAsync(ICollection<Course> courses);
    Task<bool> DeleteAsync(Course course);
    Task<Course?> GetAsync(Guid Id);
    Task<List<Course>> GetAllAsync();
}